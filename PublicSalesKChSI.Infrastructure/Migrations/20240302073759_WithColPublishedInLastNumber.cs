using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class WithColPublishedInLastNumber : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastDownNumbers");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "HtmlSeekAttribs");
        }
    }
}
