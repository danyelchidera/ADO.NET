using ADO.NET.Models;
using ADO.NET.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

        public EmployeeAndAddress GetAllEmployeeAndAdress()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "SELECT * FROM EmployeeProfile;SELECT * FROM Address";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                using (var res = cmd.ExecuteReader())
                {
                    if (res.HasRows)
                    {
                        var employees = new List<Employee>();
                        var addresses = new List<Address>();

                        while (res.Read())
                        {
                            employees.Add(
                                new Employee()
                                {
                                    ID = Convert.ToInt32(res["Id"]),
                                    FirstName = res["FirstName"].ToString(),
                                    LastName = res["LastName"].ToString(),
                                }
                            );
                        }
                        if(res.NextResult())
                        {
                            while(res.Read())
                            {
                                addresses.Add(
                                new Address()
                                {
                                    Street = res["Street"].ToString(),
                                    City = res["City"].ToString(),
                                    Country = res["Country"].ToString()
                                });
                            }
                            
                        }
                        return new EmployeeAndAddress()
                        {
                            Employees = employees,
                            Address = addresses
                        };
                    }
                    else
                    {
                        return new EmployeeAndAddress();
                    }
                }


            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                var command = "SELECT * FROM EmployeeProfile";
                
                using(SqlDataAdapter da = new SqlDataAdapter("spGetAllEmployee", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    var result = new List<Employee>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        result.Add(
                            new Employee()
                            {
                                ID = Convert.ToInt32(row["Id"]),
                                FirstName = row["FirstName"].ToString(),
                                LastName = row["LastName"].ToString(),
                            }
                        );
                        
                    }
                    return result;
                    
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
