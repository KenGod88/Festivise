using Festivise.Events.Storage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Festivise.Events.Storage.Context
{
    public class FestiviseContext : DbContext
    {
        public FestiviseContext(DbContextOptions<FestiviseContext> options) : base(options)
        {
        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<ActModel> Acts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().HasKey(e => e.Id);
            modelBuilder.Entity<ActModel>().HasKey(a => a.Id);

            
            modelBuilder.Entity<EventModel>()
                .HasMany(e => e.Acts) 
                .WithOne() 
                .HasForeignKey(a => a.EventId) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}