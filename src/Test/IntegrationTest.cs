using System;
using System.Collections.Generic;
using System.Linq;
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

            var gameService = new GameService(gameRepository);

            var newGameRequest = new NewGameRequest
            {
                MaxGuessNo = 10,
                NoOfRounds = 1,
                UsersInGame = new[] {1, 2}
            };


            var gameId = gameService.Create(newGameRequest);

        }
    }
}