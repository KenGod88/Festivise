using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivise.Events.Domain.Models;

namespace Festivise.Events.Storage.Context
{
    internal class FestiviseContext : DbContext
    {
        public DbSet<Domain.Models.Event> Events { get; set; }
        public DbSet<Domain.Models.Act> Acts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=laptop_ken\\sqlexpress;Initial Catalog=Festivise;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Domain.Models.Act>().HasKey(a => a.Id);
        }
    }
}
