using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure.Application
{
    //TODO: Service?
    public class RoundOfGame
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoundOfGame(IGameRepository gameRepository, IRoundRepository roundRepository, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            this.unitOfWork = unitOfWork;
        }

        public Round RunGame(Guid gameId, IEnumerable<UserInGame> userInGame)
        {
            var game = _gameRepository.FindById(gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            var roundsLeft = game.Run(userInGame);

            _gameRepository.UpdateGame(game);
            _roundRepository.SaveRound();


            // save game
            // save round

            return roundsLeft;
        }
    }
}
