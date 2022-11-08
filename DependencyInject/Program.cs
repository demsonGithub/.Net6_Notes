using DependencyInject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 单例
builder.Services.AddSingleton<ITestService, TestService>();
// 作用域
builder.Services.AddScoped<ITestService, TestService>();
// 瞬时
builder.Services.AddTransient<ITestService, TestService>();

builder.Services.AddScoped(typeof(OrderService));

var app = builder.Build();

var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var oder = scope.ServiceProvider.GetRequiredService<OrderService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();