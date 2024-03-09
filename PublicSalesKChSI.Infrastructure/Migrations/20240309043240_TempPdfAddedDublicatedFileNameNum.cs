using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class TempPdfAddedDublicatedFileNameNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DublicatedFileNameNum",
                table: "TempPdfs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DublicatedFileNameNum",
                table: "TempPdfs");
        }
    }
}
