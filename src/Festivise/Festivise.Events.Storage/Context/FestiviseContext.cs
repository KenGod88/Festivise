using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festivise.Events.Domain.Models;
using Microsoft.Extensions.Options;
using Festivise.Events.Storage.Options;

namespace Festivise.Events.Storage.Context
{
    public class FestiviseContext : DbContext
    {
        public FestiviseContext(DbContextOptions<FestiviseContext> options) : base(options)
        {
        }

        public DbSet<Domain.Models.Event> Events { get; set; }
        public DbSet<Domain.Models.Act> Acts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Domain.Models.Act>().HasKey(a => a.Id);
        }
    }
}