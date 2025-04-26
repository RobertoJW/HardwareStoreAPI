using Microsoft.AspNetCore.Mvc;
using HardwareStoreAPI.Modelo;
using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorUsuarios : ControllerBase
    {
        public readonly AppDbContext _context;

        public ControladorUsuarios(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario()
        {
            // Verificar si ya existe un usuario con el mismo correo
            var existingUser = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.email == "correo1@gmail.com");

            if (existingUser != null)
            {
                return BadRequest("El usuario ya existe");
            }

            // Crear un nuevo usuario
            var usuario1 = new Usuario("correo1@gmail.com", "Pochoclo", "123456789", null);

            // Agregar el nuevo usuario al contexto y guardar los cambios en la base de datos
            await _context.Usuarios.AddAsync(usuario1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario1.userId }, usuario1);
        }
    }
}
