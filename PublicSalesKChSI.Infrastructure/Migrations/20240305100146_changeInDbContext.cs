using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class changeInDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempHtmls_BrsFiles_BrsFileId",
                table: "TempHtmls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempHtmls_BrsFiles_BrsFileId",
                table: "TempHtmls");
                       
            migrationBuilder.AddForeignKey(
                name: "FK_TempHtmls_BrsFiles_BrsFileId",
                table: "TempHtmls",
                column: "BrsFileId",
                principalTable: "BrsFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
