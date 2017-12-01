using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;
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

        internal GameService CreateGameService()
        {
            var randomGeneratorStub = new RandomGeneratorStub(10);
            _unitOfWork = new UnitOfWorkStub();

            var gameService = new GameService(_gameRepository, randomGeneratorStub, _unitOfWork);

            return gameService;
        }
    }
}
