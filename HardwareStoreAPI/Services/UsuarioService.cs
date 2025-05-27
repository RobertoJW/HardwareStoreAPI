using HardwareStoreAPI.Modelo;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreAPI.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario nuevoUsuario)
        {
            // 1. Añadir el usuario
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            // 2. Crear carrito y favoritos vinculados al usuario recién creado
            var carrito = new CarritoCompra { userId = nuevoUsuario.userId };
            var favoritos = new ListaFavoritos { userId = nuevoUsuario.userId };

            _context.CarritoCompras.Add(carrito);
            _context.ListaFavoritos.Add(favoritos);
            await _context.SaveChangesAsync();

            return nuevoUsuario;
        }
        public async Task<Usuario?> ValidarCredencialesAsync(string email, string password)
        {
            return await _context.Usuarios
                .Include(u => u.CarritoCompra)
                .Include(u => u.ListaFavoritos)
                .FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }

        public async Task<List<Usuario>> GetAllUsers()
        {
            return await _context.Usuarios
                .Include(u => u.ListaFavoritos)
                .ThenInclude(lf => lf.Productos)
                .Include(u => u.CarritoCompra)
                .ThenInclude(c => c.Productos)
                .ToListAsync();
        }
    }
}
