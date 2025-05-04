using Microsoft.EntityFrameworkCore;
using HardwareStoreAPI.Modelo;

namespace HardwareStoreAPI.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Modelo.Producto> Productos { get; set; }
        public DbSet<Modelo.Usuario> Usuarios { get; set; }
        public DbSet<Modelo.CarritoCompra> CarritoCompras { get; set; }
        public DbSet<Modelo.ListaFavoritos> ListaFavoritos { get; set; }
        public DbSet<Modelo.Movil> Moviles { get; set; }
        public DbSet<Modelo.Sobremesa> Sobremesas { get; set; }
        public DbSet<Modelo.Portatil> Portatiles { get; set; }
        public DbSet<Modelo.DescripcionPortatilMovil> DescripcionPortatilMovil { get; set; }
        public DbSet<Modelo.DescripcionSobremesa> DescripcionSobremesa { get; set; }

        // metodo para indicar a Entity Framework Core las clases heredadas de Producto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .ToTable("Productos"); // Esta es la tabla base para la clase Producto
            modelBuilder.Entity<Portatil>()
                .ToTable("Portatiles"); // Esta será la tabla para Portatiles
            modelBuilder.Entity<Movil>()
                .ToTable("Moviles"); // Esta será la tabla para Moviles
            modelBuilder.Entity<Sobremesa>()
                .ToTable("Sobremesas"); // Esta será la tabla para Sobremesas

            // sirven para eliminar las descripciones en caso de que se elimine el producto
            /*modelBuilder.Entity<DescripcionPortatilMovil>()
                .HasOne(d => d.Producto)
                .WithOne()
                .HasForeignKey<DescripcionPortatilMovil>(d => d.Producto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DescripcionSobremesa>()
                .HasOne(d => d.Producto)
                .WithOne()
                .HasForeignKey<DescripcionSobremesa>(d => d.Producto)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
