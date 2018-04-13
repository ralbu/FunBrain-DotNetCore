using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public class UserRepositoryHardCoded : IUserRepository
    {
        private List<User> _users;

        public UserRepositoryHardCoded()
        {
            _users = new List<User>
            {
                new User {Id = 1, Name = "User 1", Email = "user1@email.com"},
                new User {Id = 2, Name = "User 2", Email = "user2@email.com"},
                new User {Id = 3, Name = "User 3", Email = "user3@email.com"},
                new User {Id = 4, Name = "User 4", Email = "user4@email.com"}
            };
        }

        public IEnumerable<User> Get()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User Create(UserCreate newUser)
        {
            var userToCreate = newUser.ToUser(_users.Count + 1);
            _users.Add(userToCreate);

            return userToCreate;

        }

        public User Update(int userId, UserUpdate updateUser)
        {
            var userToUpdate = _users.FirstOrDefault(user => user.Id == userId);
            userToUpdate.Name = updateUser.Name;
            userToUpdate.Email = updateUser.Email;

            return userToUpdate;
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }
    }
}