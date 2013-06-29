using DeliveryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryTracker.Repositories
{
    public class MemoryUsersRepository : IUsersRepository
    {
        private static readonly List<User> _users = new List<User>();
        static int _maxId = 0;

        public User GetByUserName(string userName)
        {
            if (userName == null) throw new ArgumentNullException("userName");
            return _users.FirstOrDefault(x => x.Name == userName);
        }

        public bool Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            var tobeUpdated = GetByUserName(user.Name);
            tobeUpdated.HintAnswer = user.HintAnswer;
            tobeUpdated.HintQuestion = user.HintQuestion;
            tobeUpdated.Password = "";
            tobeUpdated.Hash = user.Hash;
            tobeUpdated.Salt = user.Salt;
            return true;
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            user.Id = _maxId++;
            if (_users.Any(x => x.Name == user.Name)) return false;

            _users.Add(user);
            return true;
        }


        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}