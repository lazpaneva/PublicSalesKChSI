using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class MigrWithLastNumbersAndUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Published",
                table: "HtmlSeekAttribs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LastDownNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastDownNumbers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "afa39921-b6f6-4713-b90d-57e80857913d", "ira1970@abv.bg", false, false, null, "IRA1970@ABV.BG", "IRA1970@ABV.BG", "AQAAAAEAACcQAAAAEJGipGk4xLbuH0R8DjqtH0ArKIezsqpzLw01kOLwyflIWYw62Nc4t52x0Ncgxi5Rhg==", null, false, "9150f21d-0866-48a3-acab-6ff2fc9bd8d0", false, "ira1970@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 0, "ae4bd1ec-0edc-4e47-918d-03578e022abe", "ja.iv@abv.bg", false, false, null, "JA.IV@ABV.BG", "JA.IV@ABV.BG", "AQAAAAEAACcQAAAAEEB5uym39RPVfKYhqWfEE+fHY49bInnS8I2kJXnhI0viZADLAgfSNeuFhB0R3QQF+g==", null, false, "7444a3b0-a90c-4486-b968-9395d901692d", false, "ja.iv@abv.bg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastDownNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "HtmlSeekAttribs");
        }
    }
}
