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
        private IEnumerable<User> _usersInGameObsolete;
        private IEnumerable<int> _usersInGame;

        // TODO: Do I need this?
        [Obsolete]
        public Game()
        {
        }

        public Game(IRandomGenerator randomGenerator)
        {
            Id = Guid.NewGuid();
            _randomGenerator = randomGenerator;
        }

        [Obsolete]
        public Game(Guid gameId, IRandomGenerator randomGenerator)
        {
            Id = gameId;
            _randomGenerator = randomGenerator;
        }


        public int Rounds { get; private set; }
        public int RoundsLeft { get; private set; }
        public int CurrentRound { get; set; }
        public Guid Id { get; set; }

        public void Start(int noOfRounds, int maxGuessNo, IEnumerable<int> usersInGame)
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
            _usersInGameObsolete = usersInGame;
        }


        public Round Run(IEnumerable<UserInGame> userGames)
        {
            var randomNumber = _randomGenerator.Generate();

            var winner = userGames
                .Select(u =>
                    new
                    {
                        Id = u.UserId,
                        Diff = Math.Abs(u.Number - randomNumber)
                    })
                .OrderBy(a => a.Diff)
                .First();

            CurrentRound++;

            RoundsLeft--;

            return new Round(this.Id, randomNumber, winner.Id, CurrentRound);
        }
    }
}