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
        public DbSet<Modelo.CarritoCompra> CarritoCompras { get; set; }
        public DbSet<Modelo.Usuario> Usuarios { get; set; }
        public DbSet<Modelo.ListaFavoritos> ListaFavoritos { get; set; }

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

            // metodos para que Entity Framework Core pueda leer los enumerados como String y no como int
            modelBuilder.Entity<Sobremesa>()
                .Property(s => s.tipoPc)
                .HasConversion<string>();

            modelBuilder.Entity<Portatil>()
                .Property(p => p.tipoPc)
                .HasConversion<string>();

            modelBuilder.Entity<CarritoCompra>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.CarritoCompra)
                .HasForeignKey<CarritoCompra>(c => c.userId);

            modelBuilder.Entity<ListaFavoritos>()
                .HasOne(f => f.Usuario)
                .WithOne(u => u.ListaFavoritos)
                .HasForeignKey<ListaFavoritos>(f => f.userId);
        }
    }
}
