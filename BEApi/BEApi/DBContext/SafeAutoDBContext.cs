using BEApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BEApi.DBContext
{
    public class SafeAutoDBContext : DbContext
    {
        public SafeAutoDBContext(DbContextOptions<SafeAutoDBContext> options) : base(options) {}

        public DbSet<SafeAuto> SafeAutos { get; set; }
        public DbSet<InformationSafeAuto> InformationSafeAutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SafeAuto>().ToTable("SafeAuto");
            modelBuilder.Entity<InformationSafeAuto>().ToTable("InformationSafeAuto");

            modelBuilder.Entity<InformationSafeAuto>()
           .HasOne(pt => pt.SafeAuto)
           .WithMany(p => p.informationSafeAutos)
           .HasForeignKey(pt => pt.SafeAutoId);
        }
    }
}
