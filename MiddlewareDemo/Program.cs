using Microsoft.Extensions.FileProviders;
using MiddlewareDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/files",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "file"))
});

app.UseDirectoryBrowser();
app.UseDefaultFiles();
app.UseFileServer();

// Configure the HTTP request pipeline.

app.Use(async (context, next) =>
{
    //await context.Response.WriteAsync("Hello");
    await next();
    if (context.Response.HasStarted)
    {
        //一旦已经开始输出，则不能再修改响应头的内容
    }
    await context.Response.WriteAsync("Hello2");
});

app.Map("/abc", abcBuilder =>
{
    abcBuilder.Use(async (context, next) =>
    {
        //await context.Response.WriteAsync("Hello");
        await next();
        await context.Response.WriteAsync("Hello2222");
    });
});

app.MapWhen(context =>
{
    Console.WriteLine(context.Request.Query.Keys);
    return context.Request.Query.Keys.Contains("abc");
}, builder =>
{
    builder.Run(async context =>
    {
        await context.Response.WriteAsync("new abc");
    });
});

app.UseMiddleware<MyMiddleware>();

app.MapControllers();

app.Run();