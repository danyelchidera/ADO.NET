using ADO.NET.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET.Repositories
{
    public class Repository : IRepository
    {
        private readonly string _conString;

        public Repository(IConfiguration config)
        {
            _conString = config.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "SELECT * FROM EmployeeProfile";
                SqlCommand cmd = new SqlCommand(command, con);
                 con.Open();
                var res = cmd.ExecuteReader();

                if (res.HasRows)
                {
                    var result = new List<Employee>();
                    while (res.Read())
                    {
                        result.Add(
                            new Employee()
                            {
                                ID = Convert.ToInt32(res["Id"]),
                                FirstName = res["FirstName"].ToString(),
                                LastName = res["LastName"].ToString(),
                            }
                        );
                    }
                    return result;
                }
                else
                {
                    return new List<Employee>();
                }
            }
        }

        public void InsertEmployee(string FirstName, string LastName)
        {
            using(SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@ID";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(outputParameter);
                
                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine(outputParameter.Value.ToString()); 
            }
      
        }
        
        public void UpdateEmployee(int Id, string FirstName, string LastName)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = $"Update EmployeeProfile SET  FirstName = '{FirstName}', LastName = '{LastName}' WHERE ID = {Id}";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
