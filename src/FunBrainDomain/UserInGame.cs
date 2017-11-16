using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBrainDomain
{
    public class UserInGame
    {
        public UserInGame(int userId, int number)
        {
            UserId = userId;
            Number = number;
        }

        public int UserId { get; set; }
        public int Number { get; set; }
    }
}
