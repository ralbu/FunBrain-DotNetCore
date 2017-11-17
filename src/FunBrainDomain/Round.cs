using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBrainDomain
{
    public class Round
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public int GuessNo { get; set; }
        public int WinnerId { get;  set; }
        public int RoundNo { get; set; }

        public Round(Guid gameId, int guessNo, int winnerId, int roundNo)
        {
            Id = Guid.NewGuid();
            GameId = gameId;
            GuessNo = guessNo;
            WinnerId = winnerId;
        }
    }
}
