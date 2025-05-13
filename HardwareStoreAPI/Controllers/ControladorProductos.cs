using Microsoft.AspNetCore.Mvc;
using HardwareStoreAPI.Modelo;
using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorProductos : ControllerBase 
    {
        private readonly AppDbContext _context;

        public ControladorProductos(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var productos = await _context.Productos.ToListAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/productos/moviles
        [HttpGet("moviles")]
        public async Task<IActionResult> GetMoviles()
        {
            var moviles = await _context.Moviles.ToListAsync();
            return Ok(moviles);
        }

        // GET: api/productos/portatiles
        [HttpGet("portatiles")]
        public async Task<IActionResult> GetPortatiles()
        {
            var portatiles = await _context.Portatiles.ToListAsync();
            return Ok(portatiles);
        }

        // GET: api/productos/sobremesas
        [HttpGet("sobremesas")]
        public async Task<IActionResult> GetSobremesas()
        {
            var sobremesas = await _context.Sobremesas.ToListAsync();
            return Ok(sobremesas);
        }
    }
}
