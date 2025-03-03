using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ECommercePlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            try
            {
                using var connection = new SqlConnection(
                    _configuration.GetConnectionString("ApiDatabase"));
                connection.Open();
                return Ok("Database connection successful!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Connection failed: {ex.Message}");
            }
        }

        [ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("pong");
}

    }
}