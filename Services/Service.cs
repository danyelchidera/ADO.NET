using ADO.NET.Models;
using ADO.NET.Repositories;
using ADO.NET.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace ADO.NET.Services
{
    public class Service : IService
    {
        private readonly IRepository _repo;

        public Service(IRepository repo)
        {
            _repo = repo;
        }

        public void AddEmployee(string FirstName, string LastName)
        {
            _repo.InsertEmployee(FirstName, LastName);
        }

        public EmployeeAndAddress GetAllEmployeeAndAdress()
        {
            return _repo.GetAllEmployeeAndAdress();
        }

        public List<Employee> GetEmployee()
        {
            return _repo.GetAllEmployees();
        }

        public void UpdateEmployee(int Id, string FirstName, string LastName)
        {
            _repo.UpdateEmployee(Id, FirstName, LastName);
        }
    }
}
