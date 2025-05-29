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

        public ListaFavoritosController(AppDbContext context)
        {
            _context = context;
        }
            
        [HttpGet]
        public async Task<IActionResult> GetListaFavoritos()
        {
            var listaFavoritos = await _context.ListaFavoritos.ToListAsync();
            return Ok(listaFavoritos);
        }
        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarProductoAFavoritos([FromBody] FavoritoRequest request)
        {
            var lista = await _context.ListaFavoritos
                .Include(l => l.Productos)
                .FirstOrDefaultAsync(l => l.userId == request.UserId);

            if (lista == null)
            {
                return NotFound("Lista de favoritos no encontrada");
            }

            var producto = await _context.Productos.FindAsync(request.ProductoId);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            // Evita duplicados
            if (lista.Productos.Any(p => p.IdProducto == producto.IdProducto))
            {
                return BadRequest("Producto ya está en favoritos");
            }

            lista.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok("Producto agregado correctamente");
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

    }
}
