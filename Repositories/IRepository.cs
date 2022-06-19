using ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET.Repositories
{
    public interface IRepository
    {
        public void InsertEmployee(string FirstName, string LastName);
        public List<Employee> GetAllEmployees();
        public void UpdateEmployee(int Id, string FirstName, string LastName);
    }
}
