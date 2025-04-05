using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorCarritoCompra : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCarritoCompra()
        {
            return Ok(new { message = "Lista de productos en el carrito de compra" });
        }
    }
}
