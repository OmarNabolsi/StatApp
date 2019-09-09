using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatApp.API.Data;
using StatApp.API.Models;

namespace StatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Username already exists");
            
            var userToCreate = new User
            {
                Username = username
            };

            var CreatedUser = await _repo.Register(userToCreate, password);

            // return CreatedAtRoute()
            return StatusCode(201);
        }
    }
}