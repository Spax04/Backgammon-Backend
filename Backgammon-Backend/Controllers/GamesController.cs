using Backgammon_Backend.Models;
using Backgammon_Backend.Services.Service_Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GamesController : ControllerBase
    {
        private readonly IRepository _repository;

        public GamesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet,Authorize]
        public Game GetGame() =>  new Game
        {
            GameId = Guid.NewGuid(),
            Started = true,
            Name = "gameName"
        };

        [HttpPost]
        public void PostGame(Game newGame) => _repository.InsertGame(newGame);
        [HttpDelete]
        public void DeleteGame(Guid id) => _repository.DeleteGame(id);
    }
}
