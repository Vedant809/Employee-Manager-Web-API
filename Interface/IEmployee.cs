using MigrationProject.Model;
using MigrationProject.DTO;

namespace MigrationProject.Interface
{
    public interface IEmployee
    {
        Task<int> InsertEmployee(EmployeeDTO employee);
        Task<EmployeeResponseDTO> updateEmployee(EmployeeRequestDTO employee);
        List<EmployeeResponseDTO> GetEmployee();
        EmpManager getEmpManagerInfo(int empId);
    }
}
