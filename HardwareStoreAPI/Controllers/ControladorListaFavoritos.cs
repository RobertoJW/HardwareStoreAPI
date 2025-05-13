using Microsoft.AspNetCore.Mvc;
using HardwareStoreAPI.Modelo;
using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorListaFavoritos : ControllerBase
    {
        private readonly AppDbContext _context;

        public ControladorListaFavoritos(AppDbContext context)
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
