using System.Collections.Generic;
using FunBrainDomain;

namespace FunBrainInfrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        User Update(User updateUser);
        bool Delete(int userId);
    }
}