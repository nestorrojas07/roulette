using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestMasivian
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = 1000;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = 1000;
                        serverOptions.Limits.MaxRequestBodySize = 68359 * 1024;
                        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                        serverOptions.ListenAnyIP(5000);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}