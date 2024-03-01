using PublicSalesKChSI.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    internal class LastNumberDownSeeder : ISeeder
    {
        public async Task SeedAsync(PublicSalesDbContext context, IServiceProvider serviceProvider)
        {
            if (context.LastDownNumbers.Any())
            {
                return;
            }

            await context.LastDownNumbers.AddAsync(new LastDownNumber
            {
                Id = 1,
                SaleType = "asset",
                LastNumber = 7131
            });
            await context.LastDownNumbers.AddAsync(new LastDownNumber
            {
                Id = 2,
                SaleType = "vehicles",
                LastNumber = 4858
            });
            await context.LastDownNumbers.AddAsync(new LastDownNumber
            {
                Id = 3,
                SaleType = "properties",
                LastNumber = 65948
            });


        }
    }
}
