using HardwareStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDescripcionGeneral : ControllerBase
    {
        private readonly AppDbContext _context;
        public ControladorDescripcionGeneral(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDescripcionGeneral()
        {
            var descripcion = await _context.DescripcionGeneral.ToListAsync();
            return Ok(descripcion);
        }
    }
}
