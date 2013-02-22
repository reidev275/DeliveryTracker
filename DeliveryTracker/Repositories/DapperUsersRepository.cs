using DapperQueryExecutor;
using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Repositories
{
    public class DapperUsersRepository : DapperRepository, IUsersRepository
    {
        public DapperUsersRepository(IDapperQueryExecutor queryExecutor, string connectionString)
            : base(queryExecutor, connectionString) { }

        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}