using System;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure.Application
{
    public class GameService// : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IGameRepository gameRepository, IRandomGenerator randomGenerator, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _randomGenerator = randomGenerator;
            _unitOfWork = unitOfWork;
        }

        public Guid Create(NewGameRequest command)
        {
            var gameId = Guid.NewGuid();
            var game = new Game(gameId, _randomGenerator);

            game.Start(command.NoOfRounds, command.MaxGuessNo, command.UsersInGame);

            _gameRepository.CreateGame(game);

            _unitOfWork.Commit();

            return gameId;
        }

        public RoundResult RunGame(Guid gameId, IEnumerable<UserInGame> userInGame)
        {
            var game = _gameRepository.GetGame(gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            game.Run(userInGame);

            // save game
            // save round

            return new RoundResult(0, 1, 2);
        }
    }
}
