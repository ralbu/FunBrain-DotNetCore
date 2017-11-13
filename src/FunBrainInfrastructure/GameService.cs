using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public string StartGame(GameInput gameInput)
        {
            var game = new Game(new RandomGenerator());
            var gameId = game.Start(gameInput.NoOfRounds, gameInput.MaxGuessNo, gameInput.UsersInGame);

            _gameRepository.CreateGame(gameInput);

            return gameId.ToString();
        }

        public RoundResult RunGame(int gameId, IEnumerable<UserInGame> userInGame)
        {
            var game = _gameRepository.GetGame(gameId);
            return new RoundResult(0, 1, 2);
        }
    }
}
