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
    }
}
