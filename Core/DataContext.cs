﻿using Microsoft.EntityFrameworkCore;
using P_Core.Models.Models;

namespace P_Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<OGDate> OGDate { get; set; }

    }
}
