using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Inyectar servicios
builder.Services.AddScoped<UsuarioService>();

// Configurar controladores con opción para evitar referencias cíclicas
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Swagger y endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Crear las tablas si no existen y loguear resultado
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        // Si quieres que aplique migraciones automáticas, descomenta la siguiente línea:
        // dbContext.Database.Migrate();

        logger.LogInformation("Las tablas se han creado correctamente (o ya existían).");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Hubo un error al intentar crear las tablas");
    }
}

// Puedes descomentar esta línea si usas HTTPS en producción
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Captura errores al iniciar la app
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR al iniciar la app: {ex.Message}");
}
