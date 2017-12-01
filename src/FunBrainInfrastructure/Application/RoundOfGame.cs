using System;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure.Application
{
    //TODO: Service?
    public class RoundOfGame
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoundOfGame(IGameRepository gameRepository, IRoundRepository roundRepository, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _unitOfWork = unitOfWork;
        }

        public Round RunGame(Guid gameId, IEnumerable<UserInGame> usersInGame)
        {
            var game = _gameRepository.FindById(gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            var round = game.Run(usersInGame);

            // Update game because updating No of rounds
            _gameRepository.UpdateGame(game);
            _roundRepository.SaveRound();

            _unitOfWork.Commit();


            return round;
        }
    }
}
