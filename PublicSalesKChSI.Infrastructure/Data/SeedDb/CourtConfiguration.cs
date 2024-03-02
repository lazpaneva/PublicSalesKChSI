using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicSalesKChSI.Infrastructure.Data.Models;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    internal class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            var data = new SeedData();

            builder.HasData(new Court[] { 
                data.Court01,
                data.Court02,
                data.Court03,
                data.Court04,
                data.Court05,
                data.Court06,
                data.Court07,
                data.Court08,
                data.Court09,
                data.Court10,
                data.Court11,
                data.Court12,
                data.Court13,
                data.Court14,
                data.Court15,
                data.Court16,
                data.Court17,
                data.Court18,
                data.Court19,
                data.Court20,
                data.Court21,
                data.Court22,
                data.Court23,
                data.Court24,
                data.Court25,
                data.Court26,
                data.Court27,
                data.Court28,
                data.Court29,
            });
        }
    }
}
