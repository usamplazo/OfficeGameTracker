using Microsoft.EntityFrameworkCore;
using OfficeGameTracker.Entities;

namespace OfficeGameTracker.Data
{
    public class GameTrackerDbContext : DbContext
    {
        public GameTrackerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }

    }
}
