using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDescripciones : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDescripciones()
        {
            return Ok(new { message = "Todas las descripciones" });
        }
    }
}
