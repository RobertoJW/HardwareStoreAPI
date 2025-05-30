using Microsoft.AspNetCore.Mvc;
using HardwareStoreAPI.Modelo;
using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaFavoritosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ListaFavoritosController> _logger;

        public ListaFavoritosController(
            AppDbContext context,
            ILogger<ListaFavoritosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarProductoAFavoritos([FromBody] FavoritoRequest request)
        {
            try
            {
                // Asegúrate de que el DTO viene bien formado
                if (request == null || request.UserId <= 0 || request.ProductoId <= 0)
                    return BadRequest(new { error = "Request inválido" });

                // Carga la lista del usuario
                var lista = await _context.ListaFavoritos
                    .Include(l => l.Productos)
                    .FirstOrDefaultAsync(l => l.userId == request.UserId);

                if (lista == null)
                    return NotFound(new { error = "Lista de favoritos no encontrada" });

                // Busca el producto
                var producto = await _context.Productos.FindAsync(request.ProductoId);
                if (producto == null)
                    return NotFound(new { error = "Producto no encontrado" });

                // Comprueba duplicados
                if (lista.Productos.Any(p => p.IdProducto == producto.IdProducto))
                    return BadRequest(new { error = "Producto ya está en favoritos" });

                // Agrega y guarda
                lista.Productos.Add(producto);
                await _context.SaveChangesAsync();

                return Ok(new { mensaje = "Producto agregado correctamente" });
            }
            catch (Exception ex)
            {
                // Registrar el stacktrace para diagnóstico
                _logger.LogError(ex,
                    "Error agregando favorito: UserId={UserId}, ProductoId={ProductoId}",
                    request?.UserId, request?.ProductoId);

                // Devuelve JSON con detalle (solo en desarrollo; en producción omite stack)
                return StatusCode(500, new
                {
                    error = "Error interno al agregar favorito",
                    detalle = ex.Message
                });
            }
        }

        [HttpPost("quitar")]
        public async Task<IActionResult> QuitarProductoDeFavoritos([FromBody] FavoritoRequest request)
        {
            var lista = await _context.ListaFavoritos
                .Include(l => l.Productos)
                .FirstOrDefaultAsync(l => l.userId == request.UserId);

            if (lista == null)
            {
                return NotFound("Lista de favoritos no encontrada");
            }

            var producto = lista.Productos.FirstOrDefault(p => p.IdProducto == request.ProductoId);
            if (producto == null)
            {
                return NotFound("Producto no encontrado en favoritos");
            }

            lista.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok("Producto eliminado de favoritos correctamente");
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> ObtenerFavoritosDeUsuario(int userId)
        {
            var lista = await _context.ListaFavoritos
                .Include(l => l.Productos)
                .FirstOrDefaultAsync(l => l.userId == userId);

            if (lista == null)
            {
                return NotFound(new { error = "Lista de favoritos no encontrada para este usuario" });
            }

            return Ok(lista);
        }

    }
}
