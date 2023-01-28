using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Identity_Models.Users.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponse>> Get(string userId)
        {
            if (userId == string.Empty || userId == null)
                return BadRequest("User input error");

            return Ok(await _userRepository.GetUserByIdAsync(userId));
        }
    }
}
