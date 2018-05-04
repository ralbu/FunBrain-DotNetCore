using System.Collections.Generic;
using System.Linq;
using FunBrainDomain;
using FunBrainInfrastructure.Models;

namespace FunBrainInfrastructure.Repositories
{
    public class UserRepositoryInMemory : IUserRepository
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

        public IEnumerable<User> GetByIds(IEnumerable<int> users)
        {
            return Users.Where(u => users.Contains(u.Id));
        }

        public User Create(UserCreate newUser)
        {
            var userToCreate = newUser.ToUser(Users.Count + 1);

            Users.Add(userToCreate);

            return userToCreate;
        }

        public User Update(int id, UserUpdate updateUser)
        {
            if (updateUser == null)
            {
                return null;
            }

            // First? or default?
            var userToUpdate = Users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate == null)
            {
                return null;
            }

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