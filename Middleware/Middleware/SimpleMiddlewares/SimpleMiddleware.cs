namespace Middleware.SimpleMiddlewares
{
    public class SimpleMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Second Hello\n");
            await next(context);
            await context.Response.WriteAsync("End of Second Middleware ***\n");
        }
    }

    public static class SimpleMiddlewareExtension
    {
        public static IApplicationBuilder UseSimpleMiddleware(this IApplicationBuilder extendedApp)
        {
            return extendedApp.UseMiddleware<SimpleMiddleware>();
        }
    }
}


