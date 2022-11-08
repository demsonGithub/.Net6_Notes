using Microsoft.Extensions.Configuration;

namespace ConfigurationFileDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("jsonSettings.json");

            builder.AddIniFile("iniSettings.ini");

            IConfiguration configuration = builder.Build();

            Console.WriteLine(configuration.GetSection("key1").Value);
            Console.WriteLine(configuration.GetSection("key2").Value);

            MySettings mySettings = new MySettings();
            configuration.GetSection("MySettings1").Bind(mySettings, options =>
            {
                options.BindNonPublicProperties = true;
            });
            Console.WriteLine(mySettings.Name + ":" + mySettings.Age);
            Console.ReadKey();
        }
    }
}