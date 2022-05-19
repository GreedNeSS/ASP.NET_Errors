var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// #1
//app.UseDeveloperExceptionPage();

//#2
//app.Environment.EnvironmentName = "Production";

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/error");
//}

//app.Map("/error", app =>
//{
//    app.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        await context.Response.WriteAsync("Error Page");
//    });
//});

//#3
app.Environment.EnvironmentName = "Production";

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(app => app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Error Page");
    }));
}

app.Run(async context =>
{
    int a = 5;
    int b = 0;
    await context.Response.WriteAsync($"a / b = {a/b}");
});

app.Run();
