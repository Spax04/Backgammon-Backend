using Backgammon_Backend.Dto;
using Backgammon_Backend.Services.Service_Interfaces;
using Identity_Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository )
        {
            _authRepository = authRepository;
        }


        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            if(request == null)
                return BadRequest("User input error");

            return Ok(await _authRepository.RegisterUserAsync(request));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (request == null)
                return BadRequest("User input error");

            return Ok(await _authRepository.LoginUserAsync(request));
        }
    }
}
