using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigrationProject.Interface;
using MigrationProject.DTO;
using MigrationProject.Model;

namespace MigrationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger)
        {
            _employee = employee;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(EmployeeDTO employeeDTO)
        {
            var id = await _employee.InsertEmployee(employeeDTO);
            return Ok(id);
        }

        [HttpPut]

        public async Task<IActionResult> updateEmployee(EmployeeRequestDTO employee)
        {
            var updatedEmp = await _employee.updateEmployee(employee);
            return Ok(updatedEmp);
        }

        [HttpGet]
        public IActionResult getEmployee()
        {
            var emp = _employee.GetEmployee();
            return Ok(emp);
        }

        [HttpGet]
        [Route("GetManagerInfo")]
        public IActionResult getEmpManagerInfo(int Id)
        {
            var emp = _employee.getEmpManagerInfo(Id);
            return Ok(emp);
        }
    }
}
