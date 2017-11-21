using System.Collections.Generic;
using FunBrainDomain;
using Xunit;

namespace Test
{
    public class GameWinnerTest
    {
        [Fact]
        public void WhenUserGuessNumberOnce_ThenItShouldWinTheGame()
        {
            const int expectedGuessNo = 5;
            const int expectedWinnerUserId = 1;
            var randomGenerator = new RandomGeneratorStub(expectedGuessNo);
            do next: use postman to calculate game winner because it is very easy to do in domain by using a hashtable
            var game = new Game(randomGenerator);
            var usersInGame = new List<int> {expectedWinnerUserId, 2};
            game.Start(1, 100, usersInGame);

            var userGames = new List<UserInGame>
            {
                new UserInGame(expectedWinnerUserId, expectedGuessNo + 1),
                new UserInGame(2, expectedGuessNo + 50)
            };

            var round = game.Run(userGames);

            Assert.Equal(expectedWinnerUserId, game.GameWinner.Id);
        }
        
    }
}
