using Microsoft.EntityFrameworkCore;

namespace MigrationProject.Model
{
    public class Manager
    {
        public int ManagerId { get; set; } //Primary key ===> relation with Employee with managerId
        public string ManagerName { get; set; }
        
        public ICollection<Employee> Employee { get; set; } // A Manager has many employee under him
        // Manager to Employee --> One to Many Relationship

    }
}
