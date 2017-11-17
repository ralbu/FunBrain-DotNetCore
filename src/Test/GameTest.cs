using FunBrainDomain;
using System;
using System.Collections;
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

            Assert.Throws<ArgumentException>(() => game.Start(rounds, guessMaxAnonymous, new List<int>()));
        }

        [Fact]
        public void WhenStartingNewGame_ThenDoNotAllowZeroMaxGuessNo()
        {
            var game = new Game();
            var guessMax = 0;
            var roundsAnonymous = 1;

            Assert.Throws<ArgumentException>(() => game.Start(roundsAnonymous, guessMax, new List<int>())); //List<int> can be null
        }

        [Fact]
        public void WhenStartingNewGame_ThenShouldAcceptNoOfRounds()
        {
            var expectedRounds = 5;
            var guessMaxAnonymous = 10;
            var game = new Game();
            game.Start(expectedRounds, guessMaxAnonymous, new List<int>()); // null last param

            Assert.Equal(expectedRounds, game.Rounds);
        }

        [Theory]
        [InlineData(4, 3)]
        [InlineData(1, 0)]
        [InlineData(148947243, 148947242)]
        public void WhenRunTheGame_ThenNoOfRoundsLeftShouldBeLessByOne(int totalRounds, int expectedRounds)
        {
            var sut = new Game(new RandomGeneratorStub(5));
            sut.Start(totalRounds, 1, new List<int>()); // null last param
            var actualResult = sut.Run(new List<UserInGame>{new UserInGame(1, 2)});

            //TODO: fix this
//            Assert.Equal(expectedRounds, actualResult.RoundsLeft);
        }

        [Fact] // This test already above
        public void WhenRunTheGame_ThenTotalNoOfRoundsShouldNotChange()
        {
//           var sut = new Game(new RandomGeneratorStub(1)); 
//            sut.Start(5, 1, null);
//            var actualResult = sut.Run(new List<UserInGame> {new UserInGame(1, 2)});
        }



        [Fact]
        public void Game()
        {
            var game = new Game(new RandomGeneratorStub(3));
            var userGames = new List<UserInGame>
            {
                new UserInGame(1, 4),
                new UserInGame(2, 8)
            };

            var actuaResult = game.Run(userGames);

            Assert.Equal(1, actuaResult.WinnerId);
        }

        [Fact]
        public void Game2()
        {
            var game = new Game(new RandomGeneratorStub(81));
            var userGames = new List<UserInGame>
            {
                new UserInGame(1, 14),
                new UserInGame(2, 20),
                new UserInGame(3, 50),
                new UserInGame(4, 1),
                new UserInGame(5, 98)
            };

            var actuaResult = game.Run(userGames);

            Assert.Equal(5, actuaResult.WinnerId);
        }
    }
}