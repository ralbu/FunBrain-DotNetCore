using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using FunBrainInfrastructure.Repositories;
using Xunit;

namespace Test
{
    public class IntegrationTest
    {
        [Fact]
        public void Test()
        {
            var gameRepository = new GameRepositoryInMemory();
            var randomGeneratorStub = new RandomGeneratorStub(10);
            var unitOfWorkStub = new UnitOfWorkStub();

            var gameService = new GameService(gameRepository, randomGeneratorStub, unitOfWorkStub);

            var newGameRequest = new NewGameRequest
            {
                MaxGuessNo = 10,
                NoOfRounds = 1,
                UsersInGame = new[] {1, 2}
            };


            var gameId = gameService.Create(newGameRequest);

            Assert.NotNull(gameId);




        }
    }
}