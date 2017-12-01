using System;
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
            var game = new Game(_randomGenerator);

            game.Start(command.NoOfRounds, command.MaxGuessNo, command.UsersInGame);

            _gameRepository.CreateGame(game);

            _unitOfWork.Commit();

            return game.Id;
        }

        public int GetGameWinner(Guid gameId)
        {
            var game = _gameRepository.FindById(gameId);

            return game.GameWinnerId;
        }

    }
}
