using PublicSalesKChSI.Infrastructure.Data.Models;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    public class CourtSeeder : ISeeder
    {
        public async Task SeedAsync(PublicSalesDbContext context, IServiceProvider serviceProvider)
        {
            if (context.Courts.Any())
            {
                return;
            }

            await context.Courts.AddAsync(new Court
            { Id = 1,
              Town = "БЛАГОЕВГРАД",
              Number = "01"  });
            await context.Courts.AddAsync(new Court
            {
                Id = 2,
                Town = "БУРГАС",
                Number = "35"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 3,
                Town = "ВАРНА",
                Number = "02"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 4,
                Town = "ВЕЛИКО ТЪРНОВО",
                Number = "03"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 5,
                Town = "ВИДИН",
                Number = "04"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 6,
                Town = "ВРАЦА",
                Number = "05"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 7,
                Town = "ГАБРОВО",
                Number = "06"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 8,
                Town = "ДОБРИЧ",
                Number = "08"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 9,
                Town = "КЪРДЖАЛИ",
                Number = "09"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 10,
                Town = "КЮСТЕНДИЛ",
                Number = "10"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 11,
                Town = "ЛОВЕЧ",
                Number = "11"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 12,
                Town = "МОНТАНА",
                Number = "12"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 13,
                Town = "ПАЗАРДЖИК",
                Number = "13"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 14,
                Town = "ПЕРНИК",
                Number = "14"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 15,
                Town = "ПЛЕВЕН",
                Number = "15"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 16,
                Town = "ПЛОВДИВ",
                Number = "16"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 17,
                Town = "РАЗГРАД",
                Number = "17"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 18,
                Town = "РУСЕ",
                Number = "18"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 19,
                Town = "СИЛИСТРА",
                Number = "19"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 20,
                Town = "СЛИВЕН",
                Number = "20"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 21,
                Town = "СМОЛЯН",
                Number = "21"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 22,
                Town = "СТАРА ЗАГОРА",
                Number = "22"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 23,
                Town = "ТЪРГОВИЩЕ",
                Number = "23"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 24,
                Town = "ХАСКОВО",
                Number = "24"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 25,
                Town = "ШУМЕН",
                Number = "25"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 26,
                Town = "ЯМБОЛ",
                Number = "26"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 27,
                Town = "СОФИЯ ГРАД",
                Number = "27"
            });
            await context.Courts.AddAsync(new Court
            {
                Id = 28,
                Town = "СОФИЯ /СГС/",
                Number = "27"

            });
            await context.Courts.AddAsync(new Court
            {
                Id = 29,
                Town = "СОФИЯ ОКРЪГ",
                Number = "28"
            });

            await context.SaveChangesAsync();
        }
    }
}
