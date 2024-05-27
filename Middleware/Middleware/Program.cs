using Middleware.SimpleMiddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<SimpleMiddleware>();
var app = builder.Build();

// app.Use(async (HttpContext context, RequestDelegate next) =>
//     {
//         await context.Response.WriteAsync("First Hello \n");
//         await next(context);
//         await context.Response.WriteAsync("First Bye \n");
//     }
// );

//app.UseMiddleware<SimpleMiddleware>();
// app.UseSimpleMiddleware();
// app.UseHelloMiddleware();
app.UsePosterMiddleware();

// app.Run(async (HttpContext context)=>
// {
//     await context.Response.WriteAsync("Final Hello\n");
// });

app.Run();