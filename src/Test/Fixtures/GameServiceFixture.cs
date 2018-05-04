using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;
using NSubstitute;
using Test.Stubs;

namespace Test.Fixtures
{
    internal class GameServiceFixture
    {
        private readonly IGameRepository _gameRepository;
        private IUnitOfWork _unitOfWork;

        public GameServiceFixture()
        {
            _gameRepository = new GameRepositoryInMemory();
        }

        internal IGameRepository GameRepository => _gameRepository;
        internal IUnitOfWork UnitOfWork => _unitOfWork;
        private List<User> _users = new List<User>();
        private IUserRepository _userRepository;

        internal GameService CreateGameService()
        {
            var randomGeneratorStub = new RandomGeneratorStub(10);
            _unitOfWork = new UnitOfWorkStub();

            var gameService = new GameService(_gameRepository, randomGeneratorStub, _unitOfWork, _userRepository);

            return gameService;
        }

        internal GameServiceFixture WithUsers(IEnumerable<User> users)
        {
            _userRepository = Substitute.For<IUserRepository>();
            _userRepository.GetByIds(null).ReturnsForAnyArgs(users);

            var users2 = _userRepository.GetByIds(new List<int>{1, 2});

            return this;
        }
    }
}
