using Microsoft.EntityFrameworkCore;

namespace thi.netmvc.Entities
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee_Tbl> Employees { get; set; }
        public DbSet<Department_Tbl> Departments { get; set; }
    }
}