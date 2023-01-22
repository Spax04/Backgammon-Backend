using Backgammon_Backend.Data;
using Backgammon_Backend.Models;
using Backgammon_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetUsersAsync();
        }
        //[HttpGet]
        //public async Task<User> GetUser(Guid id)
        //{
        //    return await _repository.GetUserByIdAsync(id);
        //}
        [HttpPost]
        public void PostUser(User newUser) => _repository.InsertUser(newUser);
        [HttpPut]
        public void PutUser(User user) => _repository.UpdateUser(user);
        [HttpDelete]
        public void DeleteUser(Guid id) => _repository.DeleteUser(id);

    }
}
