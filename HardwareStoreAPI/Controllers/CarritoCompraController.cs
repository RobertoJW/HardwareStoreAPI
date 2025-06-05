using HardwareStoreAPI.Modelo;
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
            try
            {
                var carritoCompra = await _context.CarritoCompras
                    .Include(l => l.Productos)
                    .ToListAsync();
                return Ok(carritoCompra);
            }
            catch (Exception ex)
            {
                // Registrar el error para diagnóstico
                _logger.LogError(ex, "Error al obtener la carrito de compra");
                return StatusCode(500, new { error = "Error interno al obtener carrito de compra" });
            }
        }

        // Obtener el carrito por usuario
        [HttpGet("usuario/{userId}")]
        public async Task<IActionResult> GetCarritoUsuario(int userId)
        {
            var carrito = await _context.CarritoCompras
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.userId == userId);

            if (carrito == null)
            {
                return NotFound("Carrito no encontrado");
            }

            return Ok(carrito);
        }

        // Agregar producto al carrito
        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarProducto([FromBody] CarritoRequest request)
        {
            try
            {
                if (request == null || request.UserId <= 0 || request.ProductoId <= 0)
                    return BadRequest("Request inválido");

                var carrito = await _context.CarritoCompras
                    .Include(c => c.Productos)
                    .FirstOrDefaultAsync(c => c.userId == request.UserId);

                if (carrito == null)
                {
                    carrito = new CarritoCompra
                    {
                        userId = request.UserId,
                        Productos = new List<Producto>()
                    };
                    _context.CarritoCompras.Add(carrito);
                }

                var producto = await _context.Productos.FindAsync(request.ProductoId);
                if (producto == null)
                    return NotFound("Producto no encontrado");

                if (carrito.Productos.Any(p => p.IdProducto == producto.IdProducto))
                    return BadRequest("Producto ya está en el carrito");

                carrito.Productos.Add(producto);
                await _context.SaveChangesAsync();

                return Ok("Producto agregado al carrito");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar producto al carrito");
                return StatusCode(500, "Error interno al agregar producto");
            }
        }

        // Quitar producto del carrito
        [HttpPost("quitar")]
        public async Task<IActionResult> QuitarProducto([FromBody] CarritoRequest request)
        {
            var carrito = await _context.CarritoCompras
                .Include(c => c.Productos)
                .FirstOrDefaultAsync(c => c.userId == request.UserId);

            if (carrito == null)
                return NotFound("Carrito no encontrado");

            var producto = carrito.Productos.FirstOrDefault(p => p.IdProducto == request.ProductoId);
            if (producto == null)
                return NotFound("Producto no está en el carrito");

            carrito.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok("Producto eliminado del carrito");
        }
    }
}
