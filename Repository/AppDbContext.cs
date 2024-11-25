using Microsoft.EntityFrameworkCore;
using MigrationProject.Model;

namespace MigrationProject.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e=>e.EmpId);

            modelBuilder.Entity<Manager>()
                .HasKey(m => m.ManagerId);

            //modelBuilder.Entity<Manager>()
            //    .HasMany(e => e.Employee)
            //    .WithOne(m => m.Manager);



            modelBuilder.Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany(e => e.Employee)
                .HasForeignKey(m => m.ManagerId);

            //modelBuilder.Entity<Manager>()
            //    .HasMany(e=>e.Employee)
            //    .WithOne(m => m.Manager)
                
        }

    }
}
