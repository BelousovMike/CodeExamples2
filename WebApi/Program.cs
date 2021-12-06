using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace APS.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, config) =>
            {  
                config.AddJsonFile("DefaultData/Usages.json", true);
                config.AddJsonFile("DefaultData/ActivityTypes.json", true);
                config.AddJsonFile("DefaultData/Resourcing.json", true);
                config.AddJsonFile("DefaultData/Compliance.json", true);
                config.AddJsonFile("DefaultData/SystemCondition.json", true);
                config.AddJsonFile("DefaultData/TacticsTypesOfWork.json", true);
                config.AddJsonFile("DefaultData/TaskTypesOfWork.json", true);
                config.AddJsonFile("DefaultData/Discipline.json", true);
                config.AddJsonFile("DefaultData/AdditionalDisciplineCode.json", true);
            })
            .UseSerilog((context, configuration) =>
            {
                configuration
                    .MinimumLevel.Information()
                    .ReadFrom.Configuration(context.Configuration)
                    .WriteTo.Console();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
