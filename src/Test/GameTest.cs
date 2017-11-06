using FunBrainDomain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class GameTest
    {
        [Fact]
        public void WhenStartingNewGame_ThenDoNotAllowZeroRounds()
        {
            var game = new Game();
            var guessMaxAnonymous = 1;
            var rounds = 0;

            Assert.Throws<ArgumentException>(() => game.Start(rounds, guessMaxAnonymous, null));
        }

        [Fact]
        public void WhenStartingNewGame_ThenDoNotAllowZeroMaxGuessNo()
        {
            var game = new Game();
            var guessMax = 0;
            var roundsAnonymous = 1;

            Assert.Throws<ArgumentException>(() => game.Start(roundsAnonymous, guessMax, null));
        }

        [Fact]
        public void WhenStartingNewGame_ThenShouldAcceptNoOfRounds()
        {
            var expectedRounds = 5;
            var guessMaxAnonymous = 10;
            var game = new Game();
            game.Start(expectedRounds, guessMaxAnonymous, null);

            Assert.Equal(expectedRounds, game.Rounds);
        }

        [Fact]
        public void WhenStartARound()
        {
            var rounds = 1;
            var game = new Game();
//            game.Create(rounds);
            game.Start(rounds, 1, null);
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