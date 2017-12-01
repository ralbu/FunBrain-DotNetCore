using System.Collections.Generic;
using FunBrainDomain;
using Test.Stubs;

namespace Test.Fixtures
{
    internal class GameFixture
    {
        private Game _game;
        internal Game CreateGame(int randomGuessNo = 0)
        {
            var randomGenerator = new RandomGeneratorStub(randomGuessNo);

            _game = new Game(randomGenerator);

            return _game;
        }

        internal void StartAnyGame(int noOfRounds = 3)
        {
            var usersInGame = new List<int> {1, 2, 3};
           _game.Start(noOfRounds, 100, usersInGame); 
        }

        internal IEnumerable<UserInGame> GetUsersInGame()
        {
            return new List<UserInGame>
            {
                new UserInGame(1, 3),
                new UserInGame(2, 4),
                new UserInGame(3, 6)
            };
        }
    }
}
