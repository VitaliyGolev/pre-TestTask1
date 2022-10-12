using BlazorServerAppTest.Data;
using BlazorServerAppTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorServerAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        public EmployeeController(IEmployee iEmployee)
        {
            _IEmployee = iEmployee;
        }
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await Task.FromResult(_IEmployee.GetEmployee());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Employee employee = _IEmployee.GetEmployeeData(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(Employee employee)
        {
            _IEmployee.AddEmployee(employee);
        }
        [HttpPut]
        public void Put(Employee employee)
        {
            _IEmployee.UpdateEmployee(employee);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IEmployee.DeleteEmployee(id);
            return Ok();
        }
    }
}
