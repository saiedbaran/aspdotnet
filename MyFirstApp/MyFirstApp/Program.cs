using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["Content-type"] = "text/html";
    //
    // string path = context.Request.Path;
    // await context.Response.WriteAsync("<h1>Hello World</h1>");
    // await context.Response.WriteAsync($"<p>path: {path}</p>");
    //
    // if (context.Request.Method == "GET")
    // {
    //     if (context.Request.Query.ContainsKey("id"))
    //     {
    //         var id = context.Request.Query["id"];
    //         await context.Response.WriteAsync($"<p>request id: {id}</p>");
    //     }
    // }

    // StreamReader reader = new StreamReader(context.Request.Body);
    // string body = await reader.ReadToEndAsync();
    //
    // Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
    //
    // if (queryDict.ContainsKey("firstName"))
    // {
    //     foreach (var value in queryDict["firstName"])
    //     {
    //         await context.Response.WriteAsync($"firstName= {value}\n");
    //     }
    // }

    context.Response.Headers["content-type"] = "text/html";
    string result = "";

    if (context.Request.Method == "GET")
    {
        Int32.TryParse(GetRequestQuery(context, "firstNumber"), out var firstNumber);
        Int32.TryParse(GetRequestQuery(context, "secondNumber"), out var secondNumber);
        var operation = GetRequestQuery(context, "operation");

        switch (operation)
        {
            case "+": result = (firstNumber + secondNumber).ToString();
                break;
            case "-": result = (firstNumber - secondNumber).ToString();
                break;
            case "*": result = (firstNumber * secondNumber).ToString();
                break;
            case "/": result = (firstNumber / secondNumber).ToString();
                break;
            case "%": result = (firstNumber % secondNumber).ToString();
                break;
        }
    }

    await context.Response.WriteAsync(result);
});

string GetRequestQuery(HttpContext httpContext, string queryKey)
{
    if (httpContext.Request.Query.ContainsKey(queryKey))
    {
        return httpContext.Request.Query[queryKey];
    }
    return "";
}

app.Run();