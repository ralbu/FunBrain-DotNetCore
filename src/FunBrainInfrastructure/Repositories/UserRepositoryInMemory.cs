using System.Collections.Generic;
using System.Linq;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public class UserRepositoryInMemory: IUserRepository
    {
        public List<User> Users { get; set; } = new List<User>();

        public IEnumerable<User> Get()
        {
            return Users;
        }

        public User GetById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public User Create(UserCreate newUser)
        {
            var createdUser = new User
            {
                Id = Users.Count,
                Name = newUser.Name,
                Email = newUser.Email
            };

            Users.Add(createdUser);

            return createdUser;
        }

        public User Update(User updateUser)
        { 
            // First? or default?
            var userToUpdate = Users.FirstOrDefault(u => u.Id == updateUser.Id);

            userToUpdate.Name = updateUser.Name;
            userToUpdate.Email = updateUser.Email;

            return userToUpdate;
        }

        public bool Delete(int userId)
        {
            foreach (var user in Users)
            {
                if (user.Id == userId)
                {
                    Users.Remove(user);
                    return true;
                }
            }

            return false;
        }
    }
}
