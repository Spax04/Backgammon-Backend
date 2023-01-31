using Chat_DAL.Data;
using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatterController : ControllerBase
    {
        readonly IChatterRepository _chatterRepository;
        readonly ChatDataContext _context;
        public ChatterController(IChatterRepository chatterRepository, ChatDataContext context)
        {
            _chatterRepository = chatterRepository;
            _context = context;
        }

        [HttpGet("{token}")]
        public async Task<ActionResult<Chatter>> Get(string token)
        {
            if (token == string.Empty || token == null)
                return BadRequest("User input error");

            var tokenCheck = new JwtSecurityToken(token);

            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;

            if (!Guid.TryParse(id, out var userIdDb))
            {
                if (!(await _chatterRepository.isChatterExistAsync(userIdDb)))
                {
                    await _chatterRepository.AddChatterAsync(userIdDb, name);
                }
            }

            return Ok(await _chatterRepository.GetChatterAsync(userIdDb));
        }
    }
}
