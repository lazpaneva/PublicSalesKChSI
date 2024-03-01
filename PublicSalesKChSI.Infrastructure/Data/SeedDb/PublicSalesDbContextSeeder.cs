using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    public class PublicSalesDbContextSeeder
    {
        public async Task SeedAsync(PublicSalesDbContext context, IServiceProvider serviceProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>()?.
                CreateLogger(typeof(PublicSalesDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new LastNumberDownSeeder(),
                              new CourtSeeder(),
                           };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(context, serviceProvider);
                await context.SaveChangesAsync();
                logger?.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
