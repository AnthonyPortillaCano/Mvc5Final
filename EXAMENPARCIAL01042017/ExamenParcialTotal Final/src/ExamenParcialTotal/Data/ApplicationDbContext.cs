using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExamenParcialTotal.Models;
using ExamenParcialTotal.Models.Entities;

namespace ExamenParcialTotal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public virtual DbSet<DetalleSolicitudes> DetalleSolicitudes { get; set; }

        public virtual DbSet<Solicitudes> Solicitudes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer("server=Anthony;Database=bdExamen2017Final;Trusted_Connection=true;MultipleActiveResultSets=true");

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
