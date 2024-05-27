namespace Middleware.SimpleMiddlewares;

public class PosterMiddleware
{
    private readonly RequestDelegate _next;

    public PosterMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "GET")
        {
            await context.Response.WriteAsync("No output for GET request\n");
            return;
        }

        if (context.Request.Method == "POST")
        {
            await context.Response.WriteAsync("Begin POST Request");

            var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();

            var queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            return;
        }
        
        await context.Response.WriteAsync("Reach to middleware");
    }
}

public static class PosterMiddlewareExtension
{
    public static IApplicationBuilder UsePosterMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<PosterMiddleware>();
    }
}