using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    internal class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new IdentityUser[] { data.EmloyeeFirst, data.EmloyeeFirst });
        }
    }
}
