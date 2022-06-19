using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET.Repositories
{
    public static class Repository
    {
        //private static readonly string conString = @"Data Source=HP\MSSQLSERVER01;Initial Catalog=Employees;Integrated Security=True";
        
        public static void InsertEmployee(string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            try
            {
                var command = "INSERT INTO EmployeeProfile(FirstName, LastName) VALUES ('Ogundimu', 'Lara')";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

    }
}
