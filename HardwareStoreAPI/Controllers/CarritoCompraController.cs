using HardwareStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoCompraController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CarritoCompraController> _logger;
        public CarritoCompraController(AppDbContext context, ILogger<CarritoCompraController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarritoCompra()
        {
            var carritoCompra = await _context.CarritoCompras.ToListAsync();
            return Ok(carritoCompra);
        }

        [HttpPost("agregarProductoCarritoCompra")]
        pyblic async Task<IActionResult> AgregarProductoCarritoCompra([FromBody] reque)
    }
}
