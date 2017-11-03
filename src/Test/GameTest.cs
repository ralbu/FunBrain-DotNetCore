using FunBrainDomain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class GameTest
    {
        [Fact]
        public void WhenCreatingNewGame_ThenDoNotAllowZeroRounds()
        {
            var game = new Game();
            Assert.Throws<ArgumentException>(() => game.Create(0));
        }

        [Fact]
        public void WhenCreatingNewGame_ThenShouldAcceptNoOfRounds()
        {
            var expectedRounds = 5;
            var game = new Game();
            game.Create(expectedRounds);

            Assert.Equal(expectedRounds, game.Rounds);
        }


        [Fact]
        public void Game()
        {
            var game = new Game(new RandomGeneratorStub(3));
            var userGames = new List<UserGame>
            {
                new UserGame(1, 4),
                new UserGame(2, 8)
            };

            var actuaResult = game.Run(userGames);

            Assert.Equal(1, actuaResult.WinnerId);
        }

        [Fact]
        public void Game2()
        {
            var game = new Game(new RandomGeneratorStub(81));
            var userGames = new List<UserGame>
            {
                new UserGame(1, 14),
                new UserGame(2, 20),
                new UserGame(3, 50),
                new UserGame(4, 1),
                new UserGame(5, 98)
            };

            var actuaResult = game.Run(userGames);

            Assert.Equal(5, actuaResult.WinnerId);
        }
    }
}