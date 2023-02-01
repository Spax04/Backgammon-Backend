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

            Guid guid = Guid.Parse(id);

            if (guid != Guid.Empty)
            {
                if (!(_chatterRepository.isChatterExistAsync(guid)))
                {
                    await _chatterRepository.AddChatterAsync(guid, name);
                }
            }           
            return Ok(await _chatterRepository.GetChatterToClientAsync(guid));
        }

        //[HttpGet]
        //public async Task<IEnumerable<Chatter>> GetChattersOnline(string chatId)
        //{
        //    Guid chatGuid = Guid.Parse(chatId);
        //    if (chatGuid != Guid.Empty)
        //    {
        //        return Ok(await _chatService.GetChattersAsync(chatGuid));
        //    }
        //}

    }
}
