namespace _1._启动过程
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void RegisterService(IServiceCollection services)
        {
            Console.WriteLine("current location:" + "RegisterService");
            services.AddHttpClient();
        }

        public void SetupMiddleware(IApplicationBuilder app)
        {
            Console.WriteLine("current location:" + "SetupMiddleware");
            app.UseStaticFiles();
        }
    }
}