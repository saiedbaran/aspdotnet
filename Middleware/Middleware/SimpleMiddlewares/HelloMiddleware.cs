namespace Middleware.SimpleMiddlewares;

public class HelloMiddleware
{
    private readonly RequestDelegate _next;

    public HelloMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Query.ContainsKey("firstname") && context.Request.Query.ContainsKey("lastname"))
        {
            var firstname = context.Request.Query["firstname"];
            var lastname = context.Request.Query["lastname"];
            await context.Response.WriteAsync($"{firstname} {lastname}\n");
        }
        await _next(context);
    }
}

public static class HelloMiddlewareExtension
{
    public static IApplicationBuilder UseHelloMiddleware(this IApplicationBuilder extendedapp)
    {
        return extendedapp.UseMiddleware<HelloMiddleware>();
    }
}