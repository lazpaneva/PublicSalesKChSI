using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class BrsFilesFKDeptorOld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptorOldID",
                table: "BrsFiles",
                type: "int",
                nullable: true);

             migrationBuilder.CreateIndex(
                name: "IX_BrsFiles_DeptorOldID",
                table: "BrsFiles",
                column: "DeptorOldID");

            migrationBuilder.AddForeignKey(
                name: "FK_BrsFiles_DeptorOlds_DeptorOldID",
                table: "BrsFiles",
                column: "DeptorOldID",
                principalTable: "DeptorOlds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrsFiles_DeptorOlds_DeptorOldID",
                table: "BrsFiles");

            migrationBuilder.DropIndex(
                name: "IX_BrsFiles_DeptorOldID",
                table: "BrsFiles");

            migrationBuilder.DropColumn(
                name: "DeptorOldID",
                table: "BrsFiles");

        }
    }
}
