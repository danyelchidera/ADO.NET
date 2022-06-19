using ADO.NET.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Worker>(host.Services);
            worker.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                });
        }
    }
}
