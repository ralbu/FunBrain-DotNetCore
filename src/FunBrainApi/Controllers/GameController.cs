using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainInfrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FunBrainApi.Controllers
{
    [Route("api/game")]
    public class GameController: Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Get()
        {
            return Ok(new {Game = 1, UserName = "tarsats"});
        }


        [HttpPost("start")]
        public IActionResult Start([FromBody] GameInput gameInput)
        {
            var gameId = _gameService.StartGame(gameInput);

            // add created ad root
            return Ok(gameId);
        }


        [HttpPost("run/{gameId}")]
        public IActionResult Run(int gameId, [FromBody] IEnumerable<UserInGame> usersInGame)
        {
            var roundResult = _gameService.RunGame(gameId, usersInGame);
            if (roundResult == null)
            {
                return NotFound($"Game {gameId} not found.");
            }

            return Ok(roundResult);
        }
    }
}
