using HardwareStoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Leer configuración de DetailedErrors y DeveloperMode del appsettings.json
bool detailedErrors = builder.Configuration.GetValue<bool>("DetailedErrors");
bool developerMode = builder.Configuration.GetValue<bool>("DeveloperMode");

// Configurar DbContext con posibles opciones extra si están activadas
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

    if (detailedErrors)
    {
        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
    }
});

// Inyectar servicios
builder.Services.AddScoped<UsuarioService>();

// Configurar controladores y evitar referencias cíclicas en JSON
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Añadir autorización para evitar errores
builder.Services.AddAuthorization();

// Configurar Swagger y explorador de endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Mostrar página de errores detallada en desarrollo o si DeveloperMode está activo
if (app.Environment.IsDevelopment() || developerMode)
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

// Middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Crear tablas si no existen y loguear resultado
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        // dbContext.Database.Migrate(); // Descomenta para aplicar migraciones automáticas
        logger.LogInformation("Las tablas se han creado correctamente (o ya existían).");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Hubo un error al intentar crear las tablas");
    }
}

// app.UseHttpsRedirection(); // Descomenta si usas HTTPS

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR al iniciar la app: {ex.Message}");
    throw; // Para que el error no se trague y puedas verlo en consola/logs
}
