using ADO.NET.Repositories;
using ADO.NET.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ADO.NET
{
    public class Start
    {
        private readonly IConfiguration _config;
        private readonly IService _service;

        public Start(IConfiguration config, IService service)
        {
            _config = config;
            _service = service;
        }
        public void Run()
        {
            _service.AddEmployee("Naruto", "Sasuke");
            
        }
    }
}