using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class DeptorOldChngAndDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Appartment",
                table: "DeptorOlds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "DeptorOlds",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complex",
                table: "DeptorOlds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enrtance",
                table: "DeptorOlds",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "DeptorOlds",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PINumber",
                table: "DeptorOlds",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "DeptorOlds",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Can be city or village");

            migrationBuilder.AddColumn<string>(
                name: "Sreet",
                table: "DeptorOlds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SreetNumber",
                table: "DeptorOlds",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terrain",
                table: "DeptorOlds",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypePlace",
                table: "DeptorOlds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "0 for city and 1 for village");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appartment",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Building",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Complex",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Enrtance",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "PINumber",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Sreet",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "SreetNumber",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "Terrain",
                table: "DeptorOlds");

            migrationBuilder.DropColumn(
                name: "TypePlace",
                table: "DeptorOlds");
        }
    }
}
