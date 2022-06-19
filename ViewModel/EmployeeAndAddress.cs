using ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET.ViewModel
{
    public class EmployeeAndAddress
    {
        public EmployeeAndAddress()
        {
            Employees = new List<Employee>();
            Address = new List<Address>();
        }
        public List<Employee> Employees { get; set; }
        public List<Address> Address { get; set; }
    }
}
