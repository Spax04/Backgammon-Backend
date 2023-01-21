using Backgammon_Backend.Data;
using Backgammon_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private HrContext _context;

        public DbController(HrContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public User GetUsers()
        
    }
}
