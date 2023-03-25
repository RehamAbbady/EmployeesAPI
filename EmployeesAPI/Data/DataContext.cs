using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Data
{

    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
