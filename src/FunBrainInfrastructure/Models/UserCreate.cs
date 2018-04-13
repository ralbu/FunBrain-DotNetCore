using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;

namespace FunBrainInfrastructure.Models
{
    public class UserCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User ToUser(int nextId)
        {
            return new User
            {
                Id = nextId,
                Name = Name,
                Email = Email
            };
        }
    }
}