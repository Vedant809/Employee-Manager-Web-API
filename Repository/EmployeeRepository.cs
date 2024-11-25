using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MigrationProject.DTO;
using MigrationProject.Interface;
using MigrationProject.Model;
using Microsoft.Extensions.Logging;
using MigrationProject.DTO;

namespace MigrationProject.Repository
{
    public class EmployeeRepository:IEmployee
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly AppDbContext _context;

        public EmployeeRepository(ILogger<EmployeeRepository> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<EmployeeResponseDTO> GetEmployee()
        {
            var emp = _context.Employee.ToList();

            List<EmployeeResponseDTO> result = new List<EmployeeResponseDTO>();
            
            foreach(var i in emp)
            {
                var employee1 = new EmployeeResponseDTO()
                {
                    EmpId = i.EmpId,
                    Name = i.Name,
                    LastName = i.LastName,
                    Designation = i.Designation,
                    ManagerId = i.ManagerId,
                };
                result.Add(employee1);
            }

            return result;
        }

        public EmpManager getEmpManagerInfo(int empId)
        {
            try
            {
                var emp = _context.Employee.Single(x=>x.EmpId == empId);
                var empInfo = new EmployeeResponseDTO()
                {
                    EmpId = emp.EmpId,
                    Name = emp.Name,
                    LastName= emp.LastName,
                    Designation= emp.Designation,
                    ManagerId = emp.ManagerId
                };

                var managerInfo = _context.Manager.Single(s => s.ManagerId == emp.ManagerId);

                var manager = new ManagerResponseDTO()
                {
                    ManagerId = managerInfo.ManagerId,
                    ManagerName = managerInfo.ManagerName
                };

                var empManager = new EmpManager()
                {
                    Employee = empInfo,
                    Manager = manager
                };

                return empManager;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> InsertEmployee(EmployeeDTO employee)
        {
            try
            {
                Employee emp = new Employee()
                {
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Designation = employee.Designation,
                    ManagerId = employee.ManagerId
                };
                _context.Employee.Add(emp);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Changes saved in the database");
                var addedEmployee = _context.Employee.Single(x => x.Name == emp.Name);
                return addedEmployee.EmpId;
            }

            catch(Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
                throw ex;
            }
        }

        public async Task<EmployeeResponseDTO> updateEmployee(EmployeeRequestDTO employee)
        {
            try
            {
                //Update Request Mapping without Manager details in the request

                Employee employeeRequest = new Employee()
                {
                    EmpId = employee.EmpId,
                    Name = employee.Name,
                    LastName= employee.LastName,
                    Designation = employee.Designation,
                    ManagerId = employee.ManagerId
                };

                _context.Employee.Update(employeeRequest);

                await _context.SaveChangesAsync();

                //Mapping with the response DTO objects
                EmployeeResponseDTO employeeResponseDTO = new EmployeeResponseDTO()
                {
                    EmpId = employee.EmpId,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Designation = employee.Designation,
                    ManagerId = employee.ManagerId
                };

                return employeeResponseDTO;

            }

            catch (Exception ex) { throw; }
        }
    }
}
