using Dapper;
using DatabaseLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class EmpRL : IEmpRL
    {
        private readonly string connectionString;
        public EmpRL(IConfiguration configuartion)
        {
            connectionString = configuartion.GetConnectionString("Emp_Dapper");
        }

        public int AddEmp(EmployeeModel employee)
        {
            var query = "insert into Employee(firstName,lastName,address) values(@firstName,@lastName,@address)";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var emp = connection.Execute(query, employee);
                    return emp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var query = "SELECT * FROM Employee";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var emp = await connection.QueryAsync<EmployeeModel>(query);
                    return emp.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> GetEmpById(int empId)
        {
            var query = $"SELECT * FROM Employee where id={empId}";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var emp =  connection.Query<EmployeeModel>(query);
                    return (List<EmployeeModel>)emp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmployee(int empId, EmployeeModel employeeModel)
        {
            var query = $"update Employee SET firstName=@firstName,lastName=@lastName,address=@address where id={empId}";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var emp = connection.Execute(query, employeeModel);
                    return emp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEmployee(int empId)
        {
            var query = $"delete from Employee where id={empId}";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var emp = connection.Execute(query);
                    return emp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
