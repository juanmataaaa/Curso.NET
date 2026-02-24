using UserManagementAPI.Middleware; // Asegúrate de tener esta línea arriba

var builder = WebApplication.CreateBuilder(args);

// 1. Agregamos el soporte para controladores
builder.Services.AddControllers();

// Configuración de OpenAPI (Swagger)
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// --- INICIO DE MIDDLEWARES (Actividad 3) ---

// 1. Registro de Logs y Gestión de Errores (el que ya tienes creado)
app.UseMiddleware<CustomMiddleware>();

// 2. Autenticación por Token (el que creamos en el paso anterior)
app.UseMiddleware<ApiKeyMiddleware>();

// --- FIN DE MIDDLEWARES ---

// 2. Mapeamos los controladores para que la API responda a /api/users
app.MapControllers();

app.Run();