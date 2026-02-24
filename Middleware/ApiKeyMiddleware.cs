namespace UserManagementAPI.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string APIKEYNAME = "X-Api-Key";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Si no tiene el token correcto, devolvemos 401 Unauthorized
        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey) || 
            extractedApiKey != "TechHive-Secret-2026")
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Acceso denegado. Token inválido.");
            return;
        }

        await _next(context);
    }
}