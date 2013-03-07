using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class MemoryUsersRepository : IUsersRepository
    {
        private static readonly List<User> _users = new List<User>();

        public User GetByUserName(string userName)
        {
            if (userName == null) throw new ArgumentNullException("userName");
            return _users.FirstOrDefault(x => x.Name == userName);
        }

        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            var tobeUpdated = GetByUserName(user.Name);
            tobeUpdated.HintAnswer = user.HintAnswer;
            tobeUpdated.HintQuestion = user.HintQuestion;
            tobeUpdated.Password = user.Password;
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            if (_users.Any(x => x.Name == user.Name)) return false;

            _users.Add(user);
            return true;
        }
    }
}