using DeliveryTracker.Models;
using DeliveryTracker.Repositories;
using System;

namespace DeliveryTracker.Managers
{
    public class UsersManager : IUsersManager
    {
        readonly IUsersRepository _repository;
        readonly IPasswordHasher _hasher;

        public UsersManager(IUsersRepository repository, IPasswordHasher hasher)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            if (hasher == null) throw new ArgumentNullException("hasher");
            _repository = repository;
            _hasher = hasher;
        }

        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            user = (User)_hasher.Hash(user);
            _repository.Update(user);
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            user = (User)_hasher.Hash(user);
            return _repository.Create(user);
        }
    }
}