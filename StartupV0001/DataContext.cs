using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace P_StartupV0001
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
            

        public DbSet<P_Core.Models.Models.User> User { get; set; }
        public DbSet<P_Core.Models.Models.Permission> Permission { get; set; }
        public DbSet<P_Core.Models.Models.Status> Status { get; set; }
        public DbSet<P_Core.Models.Models.UserType> UserType { get; set; }
        public DbSet<P_Core.Models.Models.OGDate> OGDate { get; set; }

    }
}
