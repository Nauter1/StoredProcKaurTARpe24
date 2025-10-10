using Microsoft.EntityFrameworkCore;
using StoredProcedureTARpe24.Models;

namespace StoredProcedureTARpe24.Data
{
    public class StoredProcDbContext : DbContext
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options)
        : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
