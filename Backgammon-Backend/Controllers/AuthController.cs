using Backgammon_Backend.Services.Service_Interfaces;
using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
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
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<Response>> Register(RegistrationRequest request)
        {
            if (request == null)
                return BadRequest("User input error");

            return Ok(await _authRepository.RegisterationAsync(request));
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            if (request == null)
                return BadRequest("User input error");

            return Ok(await _authRepository.LoginAsync(request));
        }
        
        [HttpGet("getTest")]
        [Authorize]
        public  ActionResult<IEnumerable<User>> Get()
        {

            return Ok( _authRepository.GetAllUsers());
        }

    }
}
