
namespace MigrationProject.Model
{
    public class Employee
    {
        public int EmpId { get; set; } //Primary Key
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int ManagerId {  get; set; } //Foreign Key

        public Manager Manager { get; set; }
    }
}
