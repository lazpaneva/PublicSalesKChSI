using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSalesKChSI.Infrastructure.Migrations
{
    public partial class MigrOneWithDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrsFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Klas = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Dcng = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "to be fill when file is Ready again"),
                    Dpos = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "to be fill when file is Ready again"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFindDeptor = table.Column<bool>(type: "bit", nullable: false),
                    Scre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lica = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telf = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrsFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrsFiles_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeptorOlds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CourtExtractFromKlas = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DeptorsInfo = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptorOlds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempHtmls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberInSite = table.Column<int>(type: "int", nullable: false),
                    BrsFileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempHtmls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempHtmls_BrsFiles_BrsFileId",
                        column: x => x.BrsFileId,
                        principalTable: "BrsFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HtmlSeekAttribs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Area = table.Column<decimal>(type: "decimal(14,2)", nullable: true),
                    TypeSaleObj = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Court = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SaleDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PropertyNum = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TempHtmlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlSeekAttribs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HtmlSeekAttribs_TempHtmls_TempHtmlId",
                        column: x => x.TempHtmlId,
                        principalTable: "TempHtmls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempPdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeOfFile = table.Column<int>(type: "int", nullable: false),
                    TempHtmlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempPdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempPdfs_TempHtmls_TempHtmlId",
                        column: x => x.TempHtmlId,
                        principalTable: "TempHtmls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrsFiles_EmployeeId",
                table: "BrsFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlSeekAttribs_TempHtmlId",
                table: "HtmlSeekAttribs",
                column: "TempHtmlId");

            migrationBuilder.CreateIndex(
                name: "IX_TempHtmls_BrsFileId",
                table: "TempHtmls",
                column: "BrsFileId");

            migrationBuilder.CreateIndex(
                name: "IX_TempPdfs_TempHtmlId",
                table: "TempPdfs",
                column: "TempHtmlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "DeptorOlds");

            migrationBuilder.DropTable(
                name: "HtmlSeekAttribs");

            migrationBuilder.DropTable(
                name: "TempPdfs");

            migrationBuilder.DropTable(
                name: "TempHtmls");

            migrationBuilder.DropTable(
                name: "BrsFiles");
        }
    }
}
