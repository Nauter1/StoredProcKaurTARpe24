using Microsoft.EntityFrameworkCore;

namespace StoredProcedureTARpe24.Data
{
    public class StoredProcDbContext : DbContext
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options)
        : base(options) { }
        
    }
}
