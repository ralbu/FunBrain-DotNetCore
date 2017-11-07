using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunBrainDomain
{
    public class Game
    {
        private readonly IRandomGenerator _randomGenerator;
        private int _maxGuessNo;
        private IEnumerable<User> _usersInGame;

        public Game()
        {
        }

        public void Start(int noOfRounds, int maxGuessNo, IEnumerable<User> usersInGame)
        {
            if (noOfRounds <= 0)
            {
                throw new ArgumentException("Number of rounds should be greater than zero.");
            }
            if (maxGuessNo <= 0)
            {
                throw new ArgumentException("Max Guess No should be greater than zero.");
            }


            Rounds = noOfRounds;
            RoundsLeft = noOfRounds;
            _maxGuessNo = maxGuessNo;
            _usersInGame = usersInGame;
        }

        public int Rounds { get; private set; }
        public int RoundsLeft { get; private set; }


        public Game(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public RoundResult Run(IEnumerable<UserGame> userGames)
        {
            var randomNumber = _randomGenerator.Generate();

            var winner = userGames
                .Select(u =>
                    new
                    {
                        Id = u.Id,
                        Diff = Math.Abs(u.Number - randomNumber)
                    })
                .OrderBy(a => a.Diff)
                .First();


            RoundsLeft--;
            return new RoundResult(winner.Id, randomNumber, RoundsLeft);
        }
    }
}