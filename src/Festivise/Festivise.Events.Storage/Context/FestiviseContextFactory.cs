using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Storage.Context
{
    public class FestiviseContextFactory : IDesignTimeDbContextFactory<FestiviseContext>
    {
        public FestiviseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<FestiviseContext>();
            var connectionString = configuration["EventRepositoryOptions:ConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string was not found.");
            }
            builder.UseSqlServer(connectionString);

            return new FestiviseContext(builder.Options);
        }
    }
}