namespace MigrationProject.DTO
{
    public class EmployeeResponseDTO
    {
        public int EmpId { get; set; } //Primary Key
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int ManagerId { get; set; }
    }

    public class EmpManager
    {
        public EmployeeResponseDTO Employee { get; set; }
        public ManagerResponseDTO Manager { get; set; }
    }
}
