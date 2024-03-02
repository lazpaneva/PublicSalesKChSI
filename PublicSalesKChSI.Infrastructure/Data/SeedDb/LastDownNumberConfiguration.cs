using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSalesKChSI.Infrastructure.Data.Models;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    internal class LastDownNumberConfiguration : IEntityTypeConfiguration<LastDownNumber>
    {
        public void Configure(EntityTypeBuilder<LastDownNumber> builder)
        {
            var data = new SeedData();

            builder.HasData(new LastDownNumber[] { data.LastNumberAsset, 
                    data.LastNumberVeichles,
                    data.LastNumberProperties});
        }
    }
}
