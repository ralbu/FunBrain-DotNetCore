using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;

namespace FunBrainInfrastructure.Repositories
{

    public class GameRepositoryInMemory : IGameRepository
    {
        private readonly List<GameInput> _games = new List<GameInput>();
        private int _gameCount = 0;


        public int CreateGame(GameInput gameInput)
        {
            _games.Add(gameInput);
            _gameCount++;

            return _gameCount;
        }

        public Game GetGame(int gameId)
        {
            _games.SingleOrDefault(g => g.)
        }
    }
}
