using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunBrainDomain;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using Microsoft.AspNetCore.Mvc;

namespace FunBrainApi.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly GameService _gameService;
        private readonly RoundOfGame _roundOfGame;

        public GameController(GameService gameService, RoundOfGame roundOfGame)
        {
            _gameService = gameService;
            _roundOfGame = roundOfGame;
        }

        public IActionResult Get()
        {
            return Ok(new {Game = 1, UserName = "tarsats"});
        }


        [HttpPost("start")]
        public IActionResult Start([FromBody] NewGameRequest newGameRequest)
        {
            var gameId = _gameService.Create(newGameRequest);

            // add created ad root
            return Ok(gameId);
        }


        [HttpPost("run/{gameId}")]
        public IActionResult Run(Guid gameId, [FromBody] IEnumerable<UserInGame> usersInGame)
        {
            try
            {
                var round = _roundOfGame.RunGame(gameId, usersInGame);
                return Ok(round);
            }
            catch (GameNotFoundException)
            {
                return NotFound($"Game {gameId} not found");
            }
            catch (GameOverException)
            {
                return BadRequest("Game Over");
            }

//            var roundResult = _gameService.RunGame(gameId, usersInGame);
//            if (roundResult == null)
//            {
//                return NotFound($"Game {gameId} not found.");
//            }

//            return Ok(roundResult);
//            return Ok();
        }
    }
}