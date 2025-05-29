using Microsoft.AspNetCore.Mvc;
using HardwareStoreAPI.Modelo;
using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HardwareStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuario;

        public UsuariosController(UsuarioService user)
        {
            _usuario = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuario.GetAllUsers();
            return Ok(usuarios);
        }

        // metodo para asignar al nuevo usuario un carrito de compra y una lista de favoritos automáticamente.
        [HttpPost]
        public async Task<IActionResult> AsignarUsuarioCarritoFavorito([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                var creado = await _usuario.CrearUsuarioAsync(nuevoUsuario);
                return CreatedAtAction(nameof(GetUsuarios), new { id = creado.userId }, creado);
            }
            catch (Exception e)
            {
                var mensajeError = e.InnerException != null ? e.InnerException.Message : e.Message;
                Debug.WriteLine($"[ERROR CREAR USUARIO] {mensajeError}");

                return StatusCode(500, new
                {
                    mensaje = "El usuario no fue registrado. Posible error del servidor o datos inválidos.",
                    detalle = mensajeError
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuario login)
        {
            var usuario = await _usuario.ValidarCredencialesAsync(login.email, login.password);
            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales inválidas" });
            }
            return Ok(usuario);
        }
    }
}
