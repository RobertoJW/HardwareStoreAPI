using Microsoft.AspNetCore.Mvc;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorListaFavoritos : ControllerBase
    {
        [HttpGet]
        public IActionResult GetListaFavoritos()
        {
            return Ok(new { message = "Lista de productos favoritos" });
        }
    }
}
