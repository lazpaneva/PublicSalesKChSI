using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class AddedApplicationUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f29ee724-077e-4f6e-9684-c16e09581e26", "Ira", "Kotseva", "AQAAAAEAACcQAAAAEMZ6Aag1aQyKhkK3TlF0AEdBSrJV2qYUIvlbNyg+SkJADIdjt2n616CqFpn5eB9RGA==", "7dd2c10b-62c2-44ad-96a5-a5bf85561054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77fef554-8c65-41c2-8d7b-21dc055d15f5", "Jana", "Ivancheva", "AQAAAAEAACcQAAAAEK1upciXdk0VlT56NvkrYP6LJQ/sfLNiSgUY7Xaa1hQMaOoxpWfCcSrfhWn4rzRIyQ==", "22584785-cef2-45ea-84d7-538a45f748a8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51859957-2f1d-42a6-8e33-db97cc3dbe30", "AQAAAAEAACcQAAAAEEQr4uDMtbfVTI8Ok4H1GFVgfRLEBqDV0x3EVAstzLgzSZ3UuPL9xVF0Hkg8d/yviw==", "68b71ce7-63ec-46d1-83a3-5f6422471776" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47cda9e3-3478-4fa7-b859-b9f5fd06842c", "AQAAAAEAACcQAAAAEPhFqwwzNW9hmfJzR88l97UAX8egm/CqCoDtQvZIBicuZeuXFKgHh6qR2shXFNZvnA==", "19693d0d-9498-435a-b624-52aa834d12ae" });
        }
    }
}
