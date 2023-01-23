using Backgammon_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public TestClass Get()
        {
            var testClass = new TestClass() { Id = Guid.NewGuid(), Name = "Alex", Age = 24 };
            return testClass;
        }
    }
}
