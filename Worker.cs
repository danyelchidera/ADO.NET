using ADO.NET.Repositories;
using Microsoft.Extensions.Configuration;

namespace ADO.NET
{
    public class Worker
    {
        private readonly IConfiguration _config;

        public Worker(IConfiguration config)
        {
            _config = config;
        }
        public void Run()
        {
            Repository.InsertEmployee(_config.GetConnectionString("DefaultConnection"));
            System.Console.WriteLine(_config.GetConnectionString("DefaultConnection"));
        }
    }
}