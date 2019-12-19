using Microsoft.EntityFrameworkCore;
using MVC_Testbed.Models;

namespace MVC_Testbed.Data
{
    public class MvcTestbedContext : DbContext
    {
        public MvcTestbedContext(DbContextOptions<MvcTestbedContext> options)
            : base(options)
        {
        }

        public DbSet<Distillery> Distilleries { get; set; }
        public DbSet<Bourbon> Bourbons { get; set; }
        public DbSet<BourbonRating> BourbonRatings {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bourbon>()
                .HasOne<Distillery>(b => b.Distillery)
                .WithMany(d => d.Bourbons)
                .HasForeignKey(b => b.DistilleryId);

            modelBuilder.Entity<BourbonRating>()
                .HasOne<Bourbon>(r => r.Bourbon)
                .WithMany(b => b.Ratings)
                .HasForeignKey(r => r.BourbonId);
        }
    }
}
