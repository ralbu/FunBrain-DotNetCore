using System;
using System.Collections;
using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure.Repositories;

namespace FunBrainInfrastructure.Application
{
    //TODO: Is this a GameServce or a Game?
    public class GameService// : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        // TODO: ctor getting to big
        public GameService(IGameRepository gameRepository, IRandomGenerator randomGenerator, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _randomGenerator = randomGenerator;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
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

        public IEnumerable<User> GetUsersInGame(Guid gameId)
        {
            var game = _gameRepository.FindById(gameId);
            if (game == null)
            {
                throw new GameNotFoundException();
            }
            var usersInGame = game.UsersInGame;
            var users = _userRepository.GetByIds(usersInGame);

            return users;
        }

    }
}
