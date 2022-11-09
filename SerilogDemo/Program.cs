// ������־��ŵ�Ŀ¼
using Serilog;
using Serilog.Events;

string logPath = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
// ������־��ģ��
string serilogOutputTemplate = "Time:{Timestamp:yyyy-MM-dd HH:mm:ss.fff}  Level��[{Level:u3}]-----[{SourceContext}]{NewLine}" +
                "Message: {Message:lj}{NewLine}" +
               "{Exception}{NewLine}";

// ��ʼ������Serilog
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    .WriteTo.Console(outputTemplate: serilogOutputTemplate)
//    .WriteTo.Async(o =>
//    {
//        //������ļ�,��Ҫ�ṩ���·��������
//        o.File(logPath + "/log_.log",
//            rollingInterval: RollingInterval.Day,
//            outputTemplate: serilogOutputTemplate,
//            rollOnFileSizeLimit: true,
//            fileSizeLimitBytes: 102400000,
//            retainedFileCountLimit: 365
//            );
//    })
//    .CreateLogger();

IConfiguration serilogConfig = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(serilogConfig)
    .Enrich.FromLogContext()
    .CreateLogger();

Log.Debug("Debug");
Log.Information("LogInformation");
Log.Warning("LogWarning");
Log.Error("LogError");
Log.Fatal("LogCritical");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(dispose: true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

Log.CloseAndFlush();