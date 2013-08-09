﻿using DapperQueryExecutor;
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
			authentication.Code = Guid.NewGuid().ToString();

			var query = new DapperQuery(ConnectionString)
			{
				Sql = @"INSERT INTO UserAuthentication([Code], [UserId], [Truck])
						VALUES (@Code, @UserId, @Truck)",
				Parameters = new
				{
					Code = authentication.Code,
					UserId = authentication.UserId,
					Truck = authentication.Truck
				}
			};
			QueryExecutor.Execute(query);
			return authentication;
		}

		public Authentication GetByCode(string authCode)
		{
			var select = new DapperQuery(ConnectionString)
			{
				Sql = @"SELECT [Id], [Code], [UserId], [Truck], [Created], [Updated]
						FROM dbo.[UserAuthentication] with (NOLOCK)
						WHERE [Code] = @Code",
				Parameters = new { Code = authCode }
			};

			var result = QueryExecutor.Query<Authentication>(select).FirstOrDefault();
			if (result == null) return null;

			var update = new DapperQuery(ConnectionString)
			{
				Sql = @"UPDATE dbo.[UserAuthentication] Set [Updated] = @Updated
						WHERE [Id] = @Id",
				Parameters = new 
				{ 
					Id = result.Id,
					Updated = DateTime.UtcNow
				}
			};

			QueryExecutor.Execute(update);
			return result;
		}
	}
}