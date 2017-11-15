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
        private readonly List<NewGameRequest> _games = new List<NewGameRequest>();
        private int _gameCount = 0;


        public int CreateGame(NewGameRequest newGameRequest)
        {
            _games.Add(newGameRequest);
            _gameCount++;

            return _gameCount;
        }

        public Game GetGame(int gameId)
        {
            return null;
//            _games.SingleOrDefault(g => g.)
        }
    }
}
