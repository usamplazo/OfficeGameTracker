using Microsoft.EntityFrameworkCore;
using OfficeGameTracker.Entities;

namespace OfficeGameTracker.Data
{
    public class OfficeGameTrackerDbContext : DbContext
    {
        public OfficeGameTrackerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }

    }
}
