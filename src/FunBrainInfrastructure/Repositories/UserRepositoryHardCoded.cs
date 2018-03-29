using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public class UserRepositoryHardCoded: IUserRepository
    {
        public IEnumerable<User> Get()
        {
            return new List<User>
            {
                new User {Id = 1, Name = "User 1", Email = "user1@email.com"},
                new User {Id = 2, Name = "User 2", Email = "user2@email.com"},
                new User {Id = 3, Name = "User 3", Email = "user3@email.com"},
                new User {Id = 4, Name = "User 4", Email = "user4@email.com"}
            };
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Create(UserCreate newUser)
        {
            throw new NotImplementedException();
        }

        public User Update(UserUpdate updateUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
