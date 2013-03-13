using DapperQueryExecutor;
using DeliveryTracker.Models;
using System;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class DapperUsersRepository : DapperRepository, IUsersRepository
    {
        readonly IPasswordHasher _hasher;

        public DapperUsersRepository(IDapperQueryExecutor queryExecutor, IPasswordHasher hasher, string connectionString)
            : base(queryExecutor, connectionString) 
        {
            if (hasher == null) throw new ArgumentNullException("hasher");
            _hasher = hasher;
        }

        public User GetByUserName(string userName)
        {
            if (userName == null) throw new ArgumentNullException("userName");

            var query = new DapperQuery(ConnectionString)
            {
                Sql = "Select Id, Name, Salt, Hash, HintQuestion, HintAnswer from dbo.[User] with (nolock) where [Name] = @Name",
                Parameters = new { Name = userName }
            };
            return QueryExecutor.Query<User>(query).FirstOrDefault();
        }

        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            user = _hasher.Hash(user);
            var query = new DapperQuery(ConnectionString)
            {
                Sql = @"Update dbo.[User] set [Hash] = @Hash, [Salt] = @Salt, [hintquestion] = @HintQuestion, [hintanswer] = @HintAnswer
                        WHERE Id = @Id",
                Parameters = new {
                    Id = user.Id,
                    Password = user.Password,
                    HintQuestion = user.HintQuestion,
                    HintAnswer = user.HintAnswer
                }
            };
            QueryExecutor.Execute(query);
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            user = _hasher.Hash(user);
            var query = new DapperQuery(ConnectionString)
            {
                Sql = @"Insert into dbo.[User]([name], [Hash], [Salt], [hintquestion], [hintanswer])
                        Values(@Name, @Hash, @Salt, @HintQuestion, @HintAnswer)",
                Parameters = new  {
                   Name = user.Name,
                   Hash = user.Hash,
                   Salt = user.Salt,
                   HintQuestion = user.HintQuestion,
                   HintAnswer = user.HintAnswer
                }
            };

            try
            {
                QueryExecutor.Execute(query);
                return true;
            }
            catch (Exception)
            {
                return false;                
            }

        }
    }
}