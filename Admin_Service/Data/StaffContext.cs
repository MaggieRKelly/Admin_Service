using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Admin_Service.Models;

namespace Admin_Service.Data
{
    public class StaffContext : DbContext
    {
        public StaffContext(DbContextOptions<StaffContext> options) : base(options)
        {
        }

        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<StaffPermission> StaffPermission { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffLogin> StaffLogin { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardDetails>().ToTable("CardDetails");
            modelBuilder.Entity<StaffPermission>().ToTable("StaffPermission");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<StaffLogin>().ToTable("StaffLogin");

        }

    }
}
