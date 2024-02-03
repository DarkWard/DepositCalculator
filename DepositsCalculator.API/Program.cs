using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DepositsCalculator.API
{
    public class Program
    {

        // Git test commit
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
