using System.Collections.Generic;
using FunBrainDomain;
using Test.Fixtures;
using Test.Stubs;
using Xunit;

namespace Test
{
    public class GameWinnerTest
    {
        [Fact]
        public void WhenUserGuessesNumberInOneRound_ThenItShouldWinTheGame()
        {
            var gameFixture = new GameFixture();
            const int expectedGuessNo = 5;
            const int expectedWinnerUserId = 1;
            var usersForGame = new List<int> {expectedWinnerUserId, 2};

            var game = gameFixture.CreateGame();
            game.Start(1, 100, usersForGame);

            var usersInGame = new List<UserInGame>
            {
                new UserInGame(expectedWinnerUserId, expectedGuessNo),
                new UserInGame(2, expectedGuessNo + 50)
            };

            game.Run(usersInGame);

            Assert.Equal(expectedWinnerUserId, game.GameWinnerId);
        }

        [Fact]
        public void WhenUserGuessNo_ThenItShouldBeTheWinner()
        {
            const int expectedGuessNo = 5;
            const int expectedWinnerUserId = 2;
            var gameFixture = new GameFixture();
            const int noOfRounds = 3;
            var game = gameFixture.CreateGame(expectedGuessNo);

            var usersForGame = new List<int> {1, expectedWinnerUserId, 3};
            game.Start(noOfRounds, 100, usersForGame);

            var expectedNonWinner = new UserInGame(1, expectedGuessNo);
            var expectedWinner = new UserInGame(expectedWinnerUserId, expectedGuessNo - 4);
            var usersInGame = new List<UserInGame>()
            {
                expectedNonWinner,
                expectedWinner,
                new UserInGame(3, expectedGuessNo + 44)
            };

            game.Run(usersInGame);
            expectedNonWinner.Number = expectedGuessNo + 22;
            expectedWinner.Number = expectedGuessNo;

            game.Run(usersInGame);
            game.Run(usersInGame);

            var actualGameWinner = game.GameWinnerId;

            Assert.Equal(expectedWinner.UserId, actualGameWinner);
        }

        [Fact]
        public void WhenOneRoundAndMultipleUsers_ThenItShouldSelectTheWinner()
        {
            const int expectedGuessNo = 81;
            var game = new Game(new RandomGeneratorStub(expectedGuessNo));
            var usersForGame = new List<int> {1, 2, 3, 4, 5};
            game.Start(1, 100, usersForGame);
            var userGames = new List<UserInGame>
            {
                new UserInGame(1, 14),
                new UserInGame(2, 20),
                new UserInGame(3, expectedGuessNo),
                new UserInGame(4, 1),
                new UserInGame(5, 98)
            };

            var actuaResult = game.Run(userGames);

            Assert.Equal(3, actuaResult.WinnerId);
        }
    }
}