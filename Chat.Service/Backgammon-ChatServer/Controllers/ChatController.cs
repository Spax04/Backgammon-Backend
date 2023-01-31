using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Helpers.ModelResponses;
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
    public class ChatController : ControllerBase
    {
        private IChatRepository _chatRepository;
        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            SucceedResponse response = new SucceedResponse("Works finaly");
            return Ok(response);
        }
    }
}
