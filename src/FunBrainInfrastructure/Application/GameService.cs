using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure.Application
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public string Create(NewGameRequest newGameRequest)
        {
            var game = new Game(new RandomGenerator());
            var gameId = game.Start(newGameRequest.NoOfRounds, newGameRequest.MaxGuessNo, newGameRequest.UsersInGame);

            _gameRepository.CreateGame(newGameRequest);

            return gameId.ToString();
        }

        public RoundResult RunGame(int gameId, IEnumerable<UserInGame> userInGame)
        {
            var game = _gameRepository.GetGame(gameId);
            return new RoundResult(0, 1, 2);
        }
    }
}
