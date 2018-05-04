using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FunBrainDomain;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;
using Test.Fixtures;
using Xunit;

namespace Test
{
    public class ApplicationIntegrationTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void whenCreatingNewGame_ThenShouldCreateGameId()
        {
            var newGameRequest = new NewGameRequest
            {
                MaxGuessNo = 10,
                NoOfRounds = 1,
                UsersInGame = new[] {1, 2}
            };

            var gameService = new GameServiceFixture().CreateGameService();

            var gameId = gameService.Create(newGameRequest);

            Assert.NotEqual(Guid.Empty, gameId);
        }

        [Fact]
        public void WhenRunGame_ThenSouldCreateRound()
        {
            var newGameRequest = new NewGameRequest
            {
                MaxGuessNo = 10,
                NoOfRounds = 1,
                UsersInGame = new[] {1, 2}
            };

            var gameServiceFixture = new GameServiceFixture();
            var gameService = gameServiceFixture.CreateGameService();

            var gameId = gameService.Create(newGameRequest);

            Assert.NotEqual(Guid.Empty, gameId);

            var usersInGame = new[]
            {
                new UserInGame(1, 5),
                new UserInGame(2, 20)
            };

            var roundRepository = new RoundRepositoryInMemory();
            var roundOfGame = new RoundOfGame(gameServiceFixture.GameRepository, roundRepository,
                gameServiceFixture.UnitOfWork);

            var round = roundOfGame.RunGame(gameId, usersInGame);

            Assert.NotNull(round);
        }

        [Fact]
        public void WhenGameFinishes_ThenShouldSelectTheWinner()
        {
            var expectedGuessNo = 10;

            var gameServiceFixture = new GameServiceFixture();
            var gameService = gameServiceFixture.CreateGameService();

            var newGameRequest = new NewGameRequest
            {
                MaxGuessNo = 10,
                NoOfRounds = 3,
                UsersInGame = new[] {1, 2, 3}
            };

            var gameId = gameService.Create(newGameRequest);

            var roundRepository = new RoundRepositoryInMemory();

            var roundOfGame = new RoundOfGame(gameServiceFixture.GameRepository, roundRepository,
                gameServiceFixture.UnitOfWork);
            var expectedNonWinner = new UserInGame(1, expectedGuessNo);
            var expectedWinner = new UserInGame(2, expectedGuessNo - 4);
            var usersInGame = new List<UserInGame>
            {
                expectedNonWinner,
                expectedWinner,
                new UserInGame(3, expectedGuessNo - 5)
            };

            roundOfGame.RunGame(gameId, usersInGame);
            expectedNonWinner.Number = expectedGuessNo - 5;
            expectedWinner.Number = expectedGuessNo;

            roundOfGame.RunGame(gameId, usersInGame);
            roundOfGame.RunGame(gameId, usersInGame);

            var gameWinner = gameService.GetGameWinner(gameId);

            Assert.Equal(expectedWinner.UserId, gameWinner);
        }

        [Fact]
        public void WhenGameStarted_ShouldReturnUsersInGame()
        {
            var gameServiceFixture = new GameServiceFixture();
            var expectedUsers = _fixture.CreateMany<User>().ToList();

            var gameService = gameServiceFixture
                .WithUsers(expectedUsers)
                .CreateGameService();

            var gameRequest = new NewGameRequest
            {
                MaxGuessNo = 1,
                NoOfRounds = 1,
                UsersInGame = expectedUsers.Select(u => u.Id)
            };

            var gameId = gameService.Create(gameRequest);

            var users = gameService.GetUsersInGame(gameId).ToList();

            Assert.True(users.Count() > 1);

            expectedUsers.ForEach(eu =>
            {
                var actualUser = users.First(au => au.Id == eu.Id);

                Assert.Equal(eu, actualUser, new UserComparer());
            });

        }
    }
}