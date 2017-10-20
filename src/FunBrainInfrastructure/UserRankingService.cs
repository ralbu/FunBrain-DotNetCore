using System.Collections.Generic;
using System.Linq;
using FunBrainDomain;

namespace FunBrainInfrastructure
{
    public interface IUserRankingService
    {
        IEnumerable<UserRanking> Get();
        GameResultViewModel RunGame(IEnumerable<GameInput> gameInputs);
    }

    public class UserRankingService : IUserRankingService
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUserRankingRepository _repository;

        public UserRankingService(IRandomGenerator randomGenerator, IUserRankingRepository repository)
        {
            _randomGenerator = randomGenerator;
            _repository = repository;
        }

        public IEnumerable<UserRanking> Get()
        {
            return _repository.Get();
        }

        public GameResultViewModel RunGame(IEnumerable<GameInput> gameInputs)
        {
            var game = new Game(_randomGenerator);

            var result = game.Run(GameInput.ToUserGame(gameInputs));
            _repository.UpdateWinner(result.WinnerId);

            var allUsers = _repository.Get();
            var userName = allUsers.Where(u => u.Id == result.WinnerId).Select(u => u.Name).Single();

            return new GameResultViewModel(result.WinnerId, userName, result.RandomNumber);
        }
    }
}