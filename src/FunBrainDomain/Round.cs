using System;

namespace FunBrainDomain
{
    public class Round
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public int GuessNo { get; set; }
        public int WinnerId { get;  set; }
        public int RoundNo { get; set; }
        public bool LastRound { get; }

        public Round(Guid gameId, int guessNo, int winnerId, int roundNo, bool lastRound)
        {
            Id = Guid.NewGuid();
            GameId = gameId;
            GuessNo = guessNo;
            WinnerId = winnerId;
            RoundNo = roundNo;
            LastRound = lastRound;
        }
    }
}
