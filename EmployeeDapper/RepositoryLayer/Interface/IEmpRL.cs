using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmpRL
    {
        public int AddEmp(EmployeeModel employee);
        public Task<List<EmployeeModel>> GetAllEmployees();
        public List<EmployeeModel> GetEmpById(int empId);
        public int UpdateEmployee(int empId, EmployeeModel employeeModel);
        public int DeleteEmployee(int empId);
    }
}
