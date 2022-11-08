using Microsoft.Extensions.Configuration;

namespace ConfigurationDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"key1","value1" },
                {"section1:key","section-value" },
                {"section2:key2:section3","section3-value" },
            });

            IConfigurationRoot config = builder.Build();

            Console.WriteLine(config["key1"]);
            Console.WriteLine(config["section1:key"]);

            IConfigurationSection section = config.GetSection("section2:key2");
            Console.WriteLine(section["section3"]);
            Console.ReadKey();
        }
    }
}