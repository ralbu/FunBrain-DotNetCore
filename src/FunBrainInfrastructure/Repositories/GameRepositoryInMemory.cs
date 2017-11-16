using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure.Application;

namespace FunBrainInfrastructure.Repositories
{

    public class GameRepositoryInMemory : IGameRepository
    {
        private readonly List<Game> _games = new List<Game>();
        private int _gameCount = 0;


        public int CreateGame(Game game)
        {
            _games.Add(game);
            _gameCount++;

            return _gameCount;
        }

        public Game GetGame(Guid gameId)
        {
            return _games.SingleOrDefault(g => g.Id == gameId);
        }
    }
}
