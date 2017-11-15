using System.Collections.Generic;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Application;
using Microsoft.AspNetCore.Mvc;

namespace FunBrainApi.Controllers
{
    public class UserRankingController: Controller
    {
        
        private readonly IUserRankingService _userRankingService;

        public UserRankingController(IUserRankingService userRankingService)
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
        public IActionResult RunGame([FromBody]IEnumerable<NewGameRequest> gameInput)
        {
            var result =_userRankingService.RunGame(gameInput);

            return Ok(result);
        }
    }
}
