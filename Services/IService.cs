using ADO.NET.Models;
using ADO.NET.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET.Services
{
    public interface IService
    {
        public List<Employee> GetEmployee();
        public EmployeeAndAddress GetAllEmployeeAndAdress();
        public void AddEmployee(string FirstName, string LastName);
        public void UpdateEmployee(int Id, string FirstName, string LastName);
    }
}
