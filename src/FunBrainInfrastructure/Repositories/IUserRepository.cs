using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        User Create(UserCreate newUser);
        User Update(UserUpdate updateUser);
        bool Delete(int userId);
    }
}