using Microsoft.EntityFrameworkCore;
using WebAPIBackend.Model;

namespace WebAPIBackend.Data
{
    public class WebAPIDbContext : DbContext
    {
        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options) : base(options)
        {
            
        }

        public DbSet<Login> Logins { get; set; }
    }
}
