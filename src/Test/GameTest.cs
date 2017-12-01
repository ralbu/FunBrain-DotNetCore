using FunBrainDomain;
using System;
using System.Collections.Generic;
using Test.Fixtures;
using Xunit;

namespace Test
{
    public class GameTest
    {
        [Fact]
        public void WhenStartingNewGame_ThenDoNotAllowZeroRounds()
        {
            var game = new GameFixture().CreateGame();
            var guessMaxAnonymous = 1;
            var rounds = 0;

            Assert.Throws<ArgumentException>(() => game.Start(rounds, guessMaxAnonymous, new List<int>()));
        }

        [Fact]
        public void DoNotRunGame_IfNotStartGameFirst()
        {
            var gameFixture = new GameFixture();
            var game = new GameFixture().CreateGame();

            Assert.Throws<GameNotStartedException>(() => game.Run(gameFixture.GetUsersInGame()));
        }

        [Fact]
        public void WhenLastRoundOfGame_ShouldLastPropertyFalse()
        {
            var gameFixture = new GameFixture();
            var game = gameFixture.CreateGame();

            gameFixture.StartAnyGame(2);

            var round1 = game.Run(gameFixture.GetUsersInGame());
            Assert.False(round1.LastRound);

            var round2 = game.Run(gameFixture.GetUsersInGame());
            Assert.True(round2.LastRound);
        }

        [Fact]
        public void WhenStartingNewGame_ThenDoNotAllowZeroMaxGuessNo()
        {
            var game = new GameFixture().CreateGame();
            var guessMax = 0;
            var roundsAnonymous = 1;

            Assert.Throws<ArgumentException>(() =>
                game.Start(roundsAnonymous, guessMax, new List<int>()));
        }

        [Fact]
        public void WhenStartingNewGame_ThenShouldAcceptNoOfRounds()
        {
            var expectedRounds = 5;
            var guessMaxAnonymous = 10;
            var game = new GameFixture().CreateGame();
            game.Start(expectedRounds, guessMaxAnonymous, new List<int>());

            Assert.Equal(expectedRounds, game.TotalRounds);
        }

        [Fact]
        public void WhenRunTheGame_ThenCurrentRoundShouldIncrease()
        {
            var gameFixture = new GameFixture();
            var game = gameFixture.CreateGame();
            gameFixture.StartAnyGame();

            game.Run(gameFixture.GetUsersInGame());

            Assert.Equal(1, game.CurrentRound);
        }
    }
}