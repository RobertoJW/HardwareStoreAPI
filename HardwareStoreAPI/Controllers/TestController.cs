using HardwareStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Root() => Ok("API Running");

        [HttpGet("test")]
        public IActionResult Test() => Ok("Test endpoint OK");
    }
}