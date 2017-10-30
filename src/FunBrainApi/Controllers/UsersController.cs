using System.Collections.Generic;
using FunBrainDomain;
using FunBrainInfrastructure;
using FunBrainInfrastructure.Models;
using FunBrainInfrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FunBrainApi.Controllers
{
    [Route("api/users")]
    public class UsersController: Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var data = _userRepository.Get();

            return Ok(data);
        }

        [HttpGet("{id}", Name="GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserCreate newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User not provided");
            }
            if (string.IsNullOrWhiteSpace(newUser.Name))
            {
                return BadRequest("User name is empty");
            }

            return CreatedAtRoute("GetUserById", new {user = 1});
        }
    }
}
