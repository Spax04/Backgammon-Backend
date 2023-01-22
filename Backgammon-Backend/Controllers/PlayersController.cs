﻿using Backgammon_Backend.Models;
using Backgammon_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IRepository _repository;

        public PlayersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<Player> GetPlayer(Guid id)
        {
            return await _repository.GetPlayerByIdAsync(id);
        }

        [HttpPost]
        public void PostGame(Game newGame) => _repository.InsertGame(newGame);
        [HttpDelete]
        public void DeleteGame(Guid id) => _repository.DeleteGame(id);
    }
}
