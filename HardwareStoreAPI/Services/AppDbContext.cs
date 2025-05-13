using Microsoft.EntityFrameworkCore;
using HardwareStoreAPI.Modelo;

namespace HardwareStoreAPI.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        // Productos con herencia TPT
        public DbSet<Modelo.Producto> Productos { get; set; }
        public DbSet<Modelo.Movil> Moviles { get; set; }
        public DbSet<Modelo.Sobremesa> Sobremesas { get; set; }
        public DbSet<Modelo.Portatil> Portatiles { get; set; }
        public DbSet<Modelo.DescripcionGeneral> DescripcionGeneral { get; set; }

        // metodo para indicar a Entity Framework Core las clases heredadas de Producto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .ToTable("Productos");
            modelBuilder.Entity<Portatil>()
                .ToTable("Portatiles"); 
            modelBuilder.Entity<Movil>()
                .ToTable("Moviles");
            modelBuilder.Entity<Sobremesa>()
                .ToTable("Sobremesas");
        }
    }
}
