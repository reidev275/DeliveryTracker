using DapperQueryExecutor;
using DeliveryTracker.Models;
using System;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class DapperDeviceAuthRepository : DapperRepository, IDeviceAuthRepository
    {
        public DapperDeviceAuthRepository(IDapperQueryExecutor queryExecutor, string connectionString)
            : base(queryExecutor, connectionString) { }

        public bool CreateAuth(string auth)
        {
            var query = new DapperQuery(ConnectionString)
            {
                Sql = @"INSERT INTO DeviceAuthentication([Code]) VALUES (@Code)",
                Parameters = new { Code = auth }
            };
            try
            {
                QueryExecutor.Execute(query);
            }
            catch (Exception)
            {
                return false;
            }            
            return true;
        }

        public DeviceAuth GetDeviceAuth(string auth)
        {
            var query = new DapperQuery(ConnectionString)
            {
                Sql = @"SELECT [Code], [IsValid] FROM DeviceAuthentication with (NOLOCK) where [Code] = @Code",
                Parameters = new { Code = auth }
            };
            return QueryExecutor.Query<DeviceAuth>(query).FirstOrDefault();

        }
    }
}