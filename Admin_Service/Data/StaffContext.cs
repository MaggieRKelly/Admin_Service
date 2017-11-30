using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Admin_Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Admin_Service.Data
{
    public class StaffContext : IdentityDbContext<ApplicationUser>
    {
        public StaffContext(DbContextOptions<StaffContext> options) : base(options)
        {
        }

        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<Staff> Staff { get; set; }



        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        protected override void OnModelCreating(ModelBuilder builder) 
           
        {
            base.OnModelCreating(builder);

            builder.Entity<CardDetails>().ToTable("CardDetails");
            builder.Entity<Staff>().ToTable("Staff");

        }

    }
}
