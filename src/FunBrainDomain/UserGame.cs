using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBrainDomain
{
    public class UserGame
    {
        public UserGame(int id, int number)
        {
            Id = id;
            Number = number;
        }

        public int Id { get; set; }
        public int Number { get; set; }
    }
}
