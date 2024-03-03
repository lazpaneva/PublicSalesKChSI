using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class SeedThreeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "fa840f45-d314-4ec1-9ca4-d82f9ea0b69d", "ira1970@abv.bg", false, false, null, "IRA1970@ABV.BG", "IRA1970@ABV.BG", "AQAAAAEAACcQAAAAEHiDhdP3jyKuUei7R8NX4XOM9vOxZYOfCUYy4GfRBl1bzPKNgdaY5pEn/8moahH12A==", null, false, "79a06b83-6e3e-40f1-8b35-04ca58fdea80", false, "ira1970@abv.bg" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "a9ba3b07-10e9-414f-ab36-5ff9d08133eb", "ja.iv@abv.bg", false, false, null, "JA.IV@ABV.BG", "JA.IV@ABV.BG", "AQAAAAEAACcQAAAAECKE/DQ0eZ9P/k0+m0bYsp0WdHRlmLiiB5FAkXVPqEGQvdGJtWnpgxFClAiWDKxfcA==", null, false, "a7e6a1b3-4f42-4f2b-a50d-bb13b1d3fa29", false, "ja.iv@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Number", "Town" },
                values: new object[,]
                {
                    { 1, "01", "БЛАГОЕВГРАД" },
                    { 2, "35", "БУРГАС" },
                    { 3, "02", "ВАРНА" },
                    { 4, "03", "ВЕЛИКО ТЪРНОВО" },
                    { 5, "04", "ВИДИН" },
                    { 6, "05", "ВРАЦА" },
                    { 7, "06", "ГАБРОВО" },
                    { 8, "08", "ДОБРИЧ" },
                    { 9, "09", "КЪРДЖАЛИ" },
                    { 10, "10", "КЮСТЕНДИЛ" },
                    { 11, "11", "ЛОВЕЧ" },
                    { 12, "12", "МОНТАНА" },
                    { 13, "13", "ПАЗАРДЖИК" },
                    { 14, "14", "ПЕРНИК" },
                    { 15, "15", "ПЛЕВЕН" },
                    { 16, "16", "ПЛОВДИВ" },
                    { 17, "17", "РАЗГРАД" },
                    { 18, "18", "РУСЕ" },
                    { 19, "19", "СИЛИСТРА" },
                    { 20, "20", "СЛИВЕН" },
                    { 21, "21", "СМОЛЯН" },
                    { 22, "22", "СТАРА ЗАГОРА" },
                    { 23, "23", "ТЪРГОВИЩЕ" },
                    { 24, "24", "ХАСКОВО" },
                    { 25, "25", "ШУМЕН" },
                    { 26, "26", "ЯМБОЛ" },
                    { 27, "27", "СОФИЯ ГРАД" },
                    { 28, "27", "СОФИЯ /СГС/" },
                    { 29, "28", "СОФИЯ ОКРЪГ" }
                });

            migrationBuilder.InsertData(
                table: "LastDownNumbers",
                columns: new[] { "Id", "LastNumber", "SaleType" },
                values: new object[,]
                {
                    { 1, 7131, "asset" },
                    { 2, 4858, "vehicles" },
                    { 3, 65948, "properties" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "LastDownNumbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LastDownNumbers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LastDownNumbers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
