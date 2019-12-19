using System;
using System.Collections.Generic;
using System.Linq;
using AdvertisingBillboard.Domain;

namespace AdvertisingBillboard.Data.Memory
{
    public class UsersRepository : IUsersRepository
    {
        private ICollection<User> _users = new List<User>();
        public User[] Get()
        {
            return _users.ToArray();
        }

        public User Get(Guid id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                    return user;
            }

            return null;
        }

        public User Get(string name)
        {
            foreach (var user in _users)
            {
                if (user.Name == name)
                    return user;
            }

            return null;
        }

        public void Create(User user)
        {
            _users.Add(user);
        }

        public void Delete(Guid id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                {
                    _users.Remove(user);
                }  
            }
        }
    }
}