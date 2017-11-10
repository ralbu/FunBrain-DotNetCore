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

        public IActionResult Get()
        {
            return Ok(new {Game = 1, UserName = "tarsats"});
        }


        [HttpPost("start")]
        public IActionResult Start([FromBody] GameInput gameInput)
        {
            return Ok(gameInput);
        }


        [HttpPost("run")]
        public IActionResult Run([FromBody] IEnumerable<UserInGame> usersInGame)
        {
            return Ok(usersInGame);
        }
    }
}
