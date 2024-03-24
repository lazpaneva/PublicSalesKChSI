using Microsoft.AspNetCore.Identity;
using PublicSalesKChSI.Infrastructure.Data.Models;

namespace PublicSalesKChSI.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Court Court01 { get; set; } = null!;
        public Court Court02 { get; set; } = null!;
        public Court Court03 { get; set; } = null!;
        public Court Court04 { get; set; } = null!;
        public Court Court05 { get; set; } = null!;
        public Court Court06 { get; set; } = null!;
        public Court Court07 { get; set; } = null!;
        public Court Court08 { get; set; } = null!;
        public Court Court09 { get; set; } = null!;
        public Court Court10 { get; set; } = null!;
        public Court Court11 { get; set; } = null!;
        public Court Court12 { get; set; } = null!;
        public Court Court13 { get; set; } = null!;
        public Court Court14 { get; set; } = null!;
        public Court Court15 { get; set; } = null!;
        public Court Court16 { get; set; } = null!;
        public Court Court17 { get; set; } = null!;
        public Court Court18 { get; set; } = null!;
        public Court Court19 { get; set; } = null!; 
        public Court Court20 { get; set; } = null!;
        public Court Court21 { get; set; } = null!;
        public Court Court22 { get; set; } = null!;
        public Court Court23 { get; set; } = null!;
        public Court Court24 { get; set; } = null!;
        public Court Court25 { get; set; } = null!;
        public Court Court26 { get; set; } = null!;
        public Court Court27 { get; set; } = null!;
        public Court Court28 { get; set; } = null!;
        public Court Court29 { get; set; } = null!;

        public LastDownNumber LastNumberAsset { get; set; } = null!;
        public LastDownNumber LastNumberVeichles { get; set; } = null!;
        public LastDownNumber LastNumberProperties { get; set; } = null!;

        public ApplicationUser EmloyeeFirst { get; set; } = null!;

        public ApplicationUser EmloyeeSecond { get; set; } = null!;
        public SeedData()
        {
            SeedUsers();
            SeedCourts();
            SeedLastDownNumbers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            EmloyeeFirst = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "ja.iv@abv.bg",
                NormalizedUserName = "JA.IV@ABV.BG",
                Email = "ja.iv@abv.bg",
                NormalizedEmail = "JA.IV@ABV.BG",
                FirstName = "Jana",
                LastName = "Ivancheva"
            };

            EmloyeeFirst.PasswordHash =
                 hasher.HashPassword(EmloyeeFirst, "jana123");

            EmloyeeSecond = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "ira1970@abv.bg",
                NormalizedUserName = "IRA1970@ABV.BG",
                Email = "ira1970@abv.bg",
                NormalizedEmail = "IRA1970@ABV.BG",
                FirstName = "Ira",
                LastName = "Kotseva"
            };

            EmloyeeSecond.PasswordHash =
            hasher.HashPassword(EmloyeeSecond, "ira123");
        }

        private void SeedCourts()
        {
            Court01 = new Court
            {
                Id = 1,
                Town = "БЛАГОЕВГРАД",
                Number = "01"
            };

            Court02 = new Court {
                Id = 2,
                Town = "БУРГАС",
                Number = "35"
            };

            Court03 = new Court {
                Id = 3,
                Town = "ВАРНА",
                Number = "02"
            };

            Court04 = new Court
            {
                Id = 4,
                Town = "ВЕЛИКО ТЪРНОВО",
                Number = "03"
            };

            Court05 = new Court
            {
                Id = 5,
                Town = "ВИДИН",
                Number = "04"
            };

            Court06 = new Court
            {
                Id = 6,
                Town = "ВРАЦА",
                Number = "05"
            };

            Court07 = new Court
            {
                Id = 7,
                Town = "ГАБРОВО",
                Number = "06"
            };

            Court08 = new Court
            {
                Id = 8,
                Town = "ДОБРИЧ",
                Number = "08"
            };

            Court09 = new Court
            {
                Id = 9,
                Town = "КЪРДЖАЛИ",
                Number = "09"
            };

            Court10 = new Court
            {
                Id = 10,
                Town = "КЮСТЕНДИЛ",
                Number = "10"
            };

            Court11 = new Court
            {
                Id = 11,
                Town = "ЛОВЕЧ",
                Number = "11"
            };

            Court12 = new Court
            {
                Id = 12,
                Town = "МОНТАНА",
                Number = "12"
            };

            Court13 = new Court
            {
                Id = 13,
                Town = "ПАЗАРДЖИК",
                Number = "13"
            };

            Court14 = new Court
            {
                Id = 14,
                Town = "ПЕРНИК",
                Number = "14"
            };

            Court15 = new Court
            {
                Id = 15,
                Town = "ПЛЕВЕН",
                Number = "15"
            };

            Court16 = new Court
            {
                Id = 16,
                Town = "ПЛОВДИВ",
                Number = "16"
            };

            Court17 = new Court
            {
                Id = 17,
                Town = "РАЗГРАД",
                Number = "17"
            };

            Court18 = new Court
            {
                Id = 18,
                Town = "РУСЕ",
                Number = "18"
            };

            Court19 = new Court
            {
                Id = 19,
                Town = "СИЛИСТРА",
                Number = "19"
            };

            Court20 = new Court
            {
                Id = 20,
                Town = "СЛИВЕН",
                Number = "20"
            };

            Court21 = new Court
            {
                Id = 21,
                Town = "СМОЛЯН",
                Number = "21"
            };

            Court22 = new Court
            {
                Id = 22,
                Town = "СТАРА ЗАГОРА",
                Number = "22"
            };

            Court23 = new Court
            {
                Id = 23,
                Town = "ТЪРГОВИЩЕ",
                Number = "23"
            };

            Court24 = new Court
            {
                Id = 24,
                Town = "ХАСКОВО",
                Number = "24"
            };

            Court25 = new Court
            {
                Id = 25,
                Town = "ШУМЕН",
                Number = "25"
            };

            Court26 = new Court
            {
                Id = 26,
                Town = "ЯМБОЛ",
                Number = "26"
            };

            Court27 = new Court
            {
                Id = 27,
                Town = "СОФИЯ ГРАД",
                Number = "27"
            };

            Court28 = new Court
            {
                Id = 28,
                Town = "СОФИЯ /СГС/",
                Number = "27"
            };

            Court29 = new Court
            {
                Id = 29,
                Town = "СОФИЯ ОКРЪГ",
                Number = "28"
            };
        }

        private void SeedLastDownNumbers()
        {
            LastNumberAsset = new LastDownNumber
            {
                Id = 1,
                SaleType = "asset",
                LastNumber = 7131
            };

            LastNumberVeichles = new LastDownNumber
            {
                Id = 2,
                SaleType = "vehicles",
                LastNumber = 4858
            };

            LastNumberProperties = new LastDownNumber
            {
                Id = 3,
                SaleType = "properties",
                LastNumber = 65948
            };
        }
    }
}
