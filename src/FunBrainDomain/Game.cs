using System;
using System.Collections.Generic;
using System.Linq;

namespace FunBrainDomain
{
    public class Game
    {
        private readonly IRandomGenerator _randomGenerator;
        private IEnumerable<int> _usersInGame;
        private bool _gameStarted = false;

        public Game(IRandomGenerator randomGenerator)
        {
            Id = Guid.NewGuid();
            _randomGenerator = randomGenerator;
        }

        public Guid Id { get; }
        public int TotalRounds { get; private set; }
        public int RoundsLeft { get; private set; }
        public int CurrentRound { get; set; }
        public List<Round> Rounds { get; } = new List<Round>();

        public int GameWinnerId
        {
            get
            {
                return Rounds
                    .GroupBy(r => r.WinnerId)
                    .ToDictionary(g => g.Key, g => g.ToList())
                    .OrderByDescending(g => g.Value.Count)
                    .First()
                    .Key;
            }
        }


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

            _gameStarted = true;

            TotalRounds = noOfRounds;
            RoundsLeft = noOfRounds;
            _usersInGame = usersInGame;
        }

        public Round Run(IEnumerable<UserInGame> userGames)
        {
            if (!_gameStarted) throw new GameNotStartedException();

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
            var lastRound = TotalRounds == CurrentRound;

            var newRound = new Round(Id, randomNumber, winner.Id, CurrentRound, lastRound);

            Rounds.Add(newRound);

            return newRound;
        }
    }
}