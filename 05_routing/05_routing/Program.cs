var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endPoints =>
{
    endPoints.Map("files/{filename}.{extension}",async context =>
    {
        var fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        var extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"Map path reached at {context.Request.Path} with filename {fileName} and extension {extension}");
    });
});
#pragma warning restore ASP0014

app.Run( async context =>
{
    await context.Response.WriteAsync($"Run path reached at {context.Request.Path}");
} );


app.Run();