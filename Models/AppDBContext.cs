using Microsoft.EntityFrameworkCore;

namespace WebAppAngularAPI.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<CarList> CarList { get; set; }
    }
}
