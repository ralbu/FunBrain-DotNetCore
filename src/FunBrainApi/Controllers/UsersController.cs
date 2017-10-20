using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FunBrainApi.Controllers
{
    public class UsersController: Controller
    {
        private readonly IUserRankingService _userRankingService;

        public UsersController(IUserRankingService userRankingService)
        {
            _userRankingService = userRankingService;
        }

        [HttpGet("api/gameInput")]
        public IActionResult GetUserRanking()
        {
            var data = _userRankingService.Get();

            return Ok(data);
        }

        [HttpPost("api/rungame")]
        public IActionResult RunGame([FromBody]IEnumerable<GameInput> gameInput)
        {
            var result =_userRankingService.RunGame(gameInput);

            return Ok(result);
        }
    }
}
