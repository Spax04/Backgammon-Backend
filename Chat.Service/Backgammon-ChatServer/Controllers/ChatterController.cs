using Chat_DAL.Data;
using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Models;
using Chat_Services.Interfaces;
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
        readonly IChatService _chatService;
        public ChatterController(IChatterRepository chatterRepository, IChatService chatService)
        {
            _chatterRepository = chatterRepository;
            _chatService = chatService;
        }

        [HttpGet("{token}")]
        public async Task<ActionResult<Chatter>> Get(string token)
        {
            if (token == string.Empty || token == null)
                return BadRequest("User input error");

            var tokenCheck = new JwtSecurityToken(token);

            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;

            Guid guid = Guid.Parse(id);

            if (guid != Guid.Empty)
            {
                await _chatService.GetOrAddChatterAsync(guid, name);
            }
            else
            {
                return BadRequest("Guid null");
            }
            return Ok(await _chatterRepository.GetChatterAsync(guid));
            return Ok();
        }

    }
}
