using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBrainInfrastructure.Models
{
    //ToDO: A better name?
    public class GameCreate
    {
        public int NoOfRounds { get; set; }
        public int MaxNumber { get; set; }
        public IEnumerable<int> UsersInGame { get; set; }

        public GameCreate(int no)
        {
            
        }
        
    }
}
