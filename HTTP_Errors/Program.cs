var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// #1
//app.UseStatusCodePages();

// #2
//app.UseStatusCodePages("text/plain", "Error: Resource not found. Status code: {0}");

// #3
//app.UseStatusCodePages(async statusCodeContext =>
//{
//    var response = statusCodeContext.HttpContext.Response;
//    var path = statusCodeContext.HttpContext.Request.Path;
//    response.ContentType = "text/plain; charset=UTF-8";

//    if (response.StatusCode == 403)
//    {
//        await response.WriteAsync($"Path: {path}. Access denied");
//    }
//    else if (response.StatusCode == 404)
//    {
//        await response.WriteAsync($"Resource {path} not found");
//    }
//});

// #4
//app.UseStatusCodePagesWithRedirects("/error/{0}");
//app.Map("/error/{statusCode}", (int statusCode) => $"Error. Status code: {statusCode}");

// #5
//app.UseStatusCodePagesWithReExecute("/error/{0}");
//app.Map("/error/{statusCode}", (int statusCode) => $"Error. Status code: {statusCode}");

// #6
app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
app.Map("/error", (int code) => $"Error. Status code: {code}");

app.Map("/home", () => "Home Page!");

app.Run();
