using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmpBL : IEmpBL
    {
        IEmpRL empRL;
        public EmpBL(IEmpRL empRL)
        {
            this.empRL = empRL;
        }

        public int AddEmp(EmployeeModel employee)
        {
            try
            {
                return this.empRL.AddEmp(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<EmployeeModel>> GetAllEmployees()
        {
            try
            {
                return this.empRL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmployee(int empId, EmployeeModel employeeModel)
        {
            try
            {
                return this.empRL.UpdateEmployee(empId, employeeModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEmployee(int empId)
        {
            try
            {
                return this.empRL.DeleteEmployee(empId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> GetEmpById(int empId)
        {
            try
            {
                return this.empRL.GetEmpById(empId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
