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

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.CarritoCompra)
                .WithOne(c => c.Usuario)
                .HasForeignKey<CarritoCompra>(c => c.userId);

            modelBuilder.Entity<CarritoCompra>()
                .HasMany(c => c.Productos)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                "CarritoCompraProductos",
                j => j.HasOne<Producto>()
                .WithMany()
                .HasForeignKey("IdProducto"),
                j => j.HasOne<CarritoCompra>()
                .WithMany()
                .HasForeignKey("id_carrito") 
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.ListaFavoritos)
                .WithOne(lf => lf.Usuario)
                .HasForeignKey<ListaFavoritos>(lf => lf.userId);

            modelBuilder.Entity<ListaFavoritos>()
                .HasMany(lf => lf.Productos)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ListaFavoritosProductos",
                j => j.HasOne<Producto>()
                .WithMany()
                .HasForeignKey("IdProducto"),
                j => j.HasOne<ListaFavoritos>()
                .WithMany()
                .HasForeignKey("id_favorito")
                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
