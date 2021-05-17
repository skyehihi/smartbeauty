using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBeauty.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SmartBeauty.Models.Client> Client { get; set; }
        public DbSet<SmartBeauty.Models.Appointment> Appointment { get; set; }
        public DbSet<SmartBeauty.Models.Salon> Salon { get; set; }
        public DbSet<SmartBeauty.Models.Service> Services { get; set; }
        public DbSet<SmartBeauty.Models.Staff> Staff { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SmartBeauty.Models.Salon>().ToTable("Salon");
            modelBuilder.Entity<SmartBeauty.Models.Appointment>().ToTable("Appointment");
            modelBuilder.Entity<SmartBeauty.Models.Client>().ToTable("Client");
            modelBuilder.Entity<SmartBeauty.Models.Staff>().ToTable("Staff");
            modelBuilder.Entity<SmartBeauty.Models.Service>().ToTable("Service");

            //modelBuilder.Entity<SmartBeauty.Models.SalonService>()
            //    .HasKey(c => new { c.SalonID, c.ServiceID });
        }


    }
}
