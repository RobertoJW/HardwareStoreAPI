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
        public CarritoCompraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarritoCompra()
        {
            var carritoCompra = await _context.CarritoCompras.ToListAsync();
            return Ok(carritoCompra);
        }
    }
}
