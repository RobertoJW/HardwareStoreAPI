using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorUsuarios : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            return Ok(new { message = "Lista de usuarios" });
        }
    }
}
