using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorProductos : ControllerBase 
    {
        [HttpGet]
        public IActionResult GetProductos()
        {
            return Ok(new {message = "Lista de productos" });
        }
    }
}
