using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        IEmpBL empBL;
        public EmpController(IEmpBL empBL)
        {
            this.empBL = empBL;
        }

        [HttpPost]
        public IActionResult AddEmp(EmployeeModel employee)
        {
            try
            {
                var res = empBL.AddEmp(employee);
                if (res == 0)
                {
                    return BadRequest(new { sucess = false, Message = "Failed to add employee!!!" });
                }
                return Ok(new { sucess = true, Message = $"Employee added Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> emp = new List<EmployeeModel>();
                emp = await empBL.GetAllEmployees();
                return Ok(new { success = true, Message = "All Employees fetch successfully", data = emp });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetEmployeeById/{empId}")]
        public async Task<IActionResult> GetEmpById(int empId)
        {
            try
            {
                List<EmployeeModel> empList = new List<EmployeeModel>();
                var empbyId = empBL.GetEmpById(empId);
                return Ok(new { sucess = true, Message = "Employee's data fetched Successfully...", data = empbyId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int empId, EmployeeModel employeeModel)
        {
            try
            {
                var result = empBL.UpdateEmployee(empId, employeeModel);
                if (result == 0)
                {
                    return this.BadRequest(new { sucess = false, Message = "Failed to update records!!!" });
                }
                return this.Ok(new { sucess = true, Message = "Employee details Updated Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int empId)
        {
            try
            {
                var result = empBL.DeleteEmployee(empId);
                if (result == 0)
                {
                    return this.BadRequest(new { sucess = false, Message = "Failed to delete employee!!!" });
                }
                return this.Ok(new { sucess = true, Message = $"Employee Id = {empId} deleted sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
