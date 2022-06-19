using ADO.NET.Repositories;
using ADO.NET.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data.SqlClient;

namespace ADO.NET
{
    public class Program
    {
        static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            var start = ActivatorUtilities.CreateInstance<Start>(host.Services);
            start.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IService, Service>();
                    services.AddScoped<IRepository, Repository>();
                    
                });
        }
    }
}
