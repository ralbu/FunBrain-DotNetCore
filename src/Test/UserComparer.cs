using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;

namespace Test
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return Equals(x.Id, y.Id)
                   && Equals(x.Name, y.Name)
                   && Equals(x.Email, y.Email);
        }

        public int GetHashCode(User obj)
        {
            return obj.Id.GetHashCode()
                   ^ obj.Name.GetHashCode()
                   ^ obj.Email.GetHashCode();
        }
    }
}