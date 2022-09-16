using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var foramt = "ddMMMyyyy";
            

            Log.Logger = new LoggerConfiguration().WriteTo.File($"C:\\temp\\Log\\Log_{DateTime.Today.ToString(foramt)}").CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(_ =>
                {
                    _.ClearProviders();
                    _.AddSerilog();
                    _.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
