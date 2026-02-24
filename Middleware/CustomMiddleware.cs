using System.Net;
using System.Text.Json;

namespace UserManagementAPI.Middleware;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomMiddleware> _logger;

    public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Paso 2: Registro de solicitud (Logging)
            _logger.LogInformation("Solicitud: {method} {path}", context.Request.Method, context.Request.Path);
            
            await _next(context);

            // Registro de respuesta
            _logger.LogInformation("Respuesta: {code}", context.Response.StatusCode);
        }
        catch (Exception ex)
        {
            // Paso 3: Gestión de errores estandarizada
            _logger.LogError(ex, "Ha ocurrido un error no controlado.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new { error = "Internal server error." };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}