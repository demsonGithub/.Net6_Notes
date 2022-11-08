using _1._Æô¶¯¹ý³Ì;
using Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("myjson.json", true, true);
builder.Configuration.AddIniFile("myIniFIle.ini", true);

//builder.Logging.AddJsonConsole();
//builder.WebHost.UseWebRoot("webroot");

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>((hostContext, autofacBuilder) =>
{
    autofacBuilder.RegisterModule(new MyAutofacModuleRegister());
});

var startup = new Startup(builder.Configuration);

startup.RegisterService(builder.Services);

//builder.WebHost.UseUrls("http://localhost:5401");

var app = builder.Build();

app.Urls.Add("http://localhost:5402");

app.UseDeveloperExceptionPage();
startup.SetupMiddleware(app);

app.MapGet("/", () => "Hello World!");

app.Run();