namespace MigrationProject.DTO
{
    public class EmployeeDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int ManagerId { get; set; }
    }

    public class EmployeeRequestDTO
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int ManagerId { get; set; }
    }
}
