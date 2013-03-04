using DapperQueryExecutor;
using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveryTracker.Repositories
{
    public class DapperAuthenticationsRepository : DapperRepository, IAuthenticationsRepository
    {
        public DapperAuthenticationsRepository(IDapperQueryExecutor queryExecutor, string connectionString)
            : base(queryExecutor, connectionString) { }

        public AuthenticationResponse Save(Authentication authentication)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResponse GetByCode(string authCode)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResponse GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}