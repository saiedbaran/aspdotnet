var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
    {
        await context.Response.WriteAsync("First Hello \n");
        await next(context);
        await context.Response.WriteAsync("First Bye \n");
    }
);

app.Use(async (HttpContext context, RequestDelegate next) =>
    {
        await context.Response.WriteAsync("Second Hello \n");
        await next(context);
        await context.Response.WriteAsync("Second Bye \n");
    }
);


app.Run(async (HttpContext context)=>
{
    await context.Response.WriteAsync("Final Hello");
});

app.Run();