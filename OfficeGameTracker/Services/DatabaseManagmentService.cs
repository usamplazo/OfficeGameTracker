using Microsoft.EntityFrameworkCore;
using OfficeGameTracker.Data;

namespace OfficeGameTracker.Services
{
    public class DatabaseManagmentService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<OfficeGameTrackerDbContext>().Database.Migrate();
            }
        }
    }
}
