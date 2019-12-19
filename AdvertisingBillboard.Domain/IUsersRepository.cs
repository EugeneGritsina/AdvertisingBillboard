using System;

namespace AdvertisingBillboard.Domain
{
    public interface IUsersRepository
    {
        User[] Get();
        User Get(Guid id);
        User Get(string name);
        void Create(User user);
        void Delete(Guid id);
    }
}