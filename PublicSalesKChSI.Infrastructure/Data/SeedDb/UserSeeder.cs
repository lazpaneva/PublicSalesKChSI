using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    public class UserSeeder
    {
        private IdentityUser EmloyeeFirst { get; set; } = null!;

        private IdentityUser EmloyeeSecond { get; set; } = null!;

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            EmloyeeFirst = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "ja.iv@abv.bg",
                NormalizedUserName = "JA.IV@ABV.BG",
                Email = "ja.iv@abv.bg",
                NormalizedEmail = "JA.IV@ABV.BG"
            };

            EmloyeeFirst.PasswordHash =
                 hasher.HashPassword(EmloyeeFirst, "jana123");

            EmloyeeSecond = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "ira1970@abv.bg",
                NormalizedUserName = "IRA1970@ABV.BG",
                Email = "ira1970@abv.bg",
                NormalizedEmail = "IRA1970@ABV.BG"
            };

            EmloyeeSecond.PasswordHash =
            hasher.HashPassword(EmloyeeSecond, "ira123");
        }
    }
}
