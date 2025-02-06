using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Update DbSet to refer to EmployeeRecord instead of Employee
        public DbSet<EmployeeRecord> Employees { get; set; }
    }
}
