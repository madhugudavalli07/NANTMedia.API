using Microsoft.EntityFrameworkCore;
using NANTMedia.API.Models;

namespace NANTMedia.API.Data
{
    public class ApplicationDbContext :DbContext

    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
             
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Ad> Ads { get; set; }
        public DbSet<Models.AdLog> AdLogs { get; set; }
    }
}
