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
    }
}
