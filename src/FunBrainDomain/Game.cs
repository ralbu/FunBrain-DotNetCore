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

        public Game()
        {
        }

        public int Rounds { get; private set; }

        public void Create(int noOfRounds)
        {
            if (noOfRounds <= 0)
            {
                throw new ArgumentException("Number of rounds should be greater than zero.");
            }

            Rounds = noOfRounds;
        }


        public Game(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public GameResult Run(IEnumerable<UserGame> userGames)
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


            return new GameResult(winner.Id, randomNumber);
        }
    }
}