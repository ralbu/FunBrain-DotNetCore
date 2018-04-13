using System.Linq;
using FunBrainInfrastructure.Models;
using FunBrainInfrastructure.Repositories;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}", Name="GetUser")]
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
            var createdUser = _userRepository.Create(newUser);

            return CreatedAtRoute("GetUser", new {id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdate updateUser)
        {
            var updatedUser = _userRepository.Update(id, updateUser);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{id}") ]
        public IActionResult PartiallyUpdate(int id, [FromBody]JsonPatchDocument<UserUpdate> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var userFromStore = _userRepository.Get().FirstOrDefault(u => u.Id == id);
            if (userFromStore == null)
            {
                return NotFound();
            }

            var userToPatch = new UserUpdate
            {
                Name = userFromStore.Name,
                Email = userFromStore.Email
            };

            patchDoc.ApplyTo(userToPatch);
            userToPatch.Id = id;

            _userRepository.Update(id, userToPatch);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _userRepository.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
