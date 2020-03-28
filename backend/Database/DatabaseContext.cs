using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}