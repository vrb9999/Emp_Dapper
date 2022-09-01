using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmpBL
    {
        public int AddEmp(EmployeeModel employee);
        public Task<List<EmployeeModel>> GetAllEmployees();
        public List<EmployeeModel> GetEmpById(int empId);
        public int UpdateEmployee(int empId, EmployeeModel employeeModel);
        public int DeleteEmployee(int empId);
    }
}
