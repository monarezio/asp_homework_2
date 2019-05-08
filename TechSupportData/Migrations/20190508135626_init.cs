using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechSupportData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QeustionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAttachment = table.Column<bool>(nullable: false, defaultValue: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QeustionId);
                    table.ForeignKey(
                        name: "FK_Questions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    ResultionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTimeResolved = table.Column<DateTime>(nullable: false),
                    QeustionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.ResultionId);
                    table.ForeignKey(
                        name: "FK_Resolutions_Questions_QeustionId",
                        column: x => x.QeustionId,
                        principalTable: "Questions",
                        principalColumn: "QeustionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Notebooks" },
                    { 2, "PCs" },
                    { 3, "Video Games" },
                    { 4, "Smart Phones" },
                    { 5, "TVs" },
                    { 6, "Software" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "Macbook Air 2018", 1 },
                    { 25, "Windows 8 Home", 6 },
                    { 24, "Windows 10 Home", 6 },
                    { 23, "Windows 10 Pro", 6 },
                    { 21, "55\" Sony Bravia KD-55XF8577", 5 },
                    { 20, "55\" LG 55UK6470PLC", 5 },
                    { 19, "Samsung Galaxy S8", 4 },
                    { 18, "Samsung Galaxy S9", 4 },
                    { 17, "Samsung Galaxy S10", 4 },
                    { 16, "iPhone XR", 4 },
                    { 15, "iPhone X", 4 },
                    { 14, "iPhone 8", 4 },
                    { 13, "iPhone 7", 4 },
                    { 12, "Sid Meier's Civilisation IV", 3 },
                    { 11, "Sid Meier's Civilisation V", 3 },
                    { 10, "Sid Meier's Civilisation VI", 3 },
                    { 9, "Counter Strike: Source", 3 },
                    { 8, "Counter Strike 1.6", 3 },
                    { 7, "Counter Strike: Global Offensive", 3 },
                    { 6, "Acer Nitro GX50-600", 2 },
                    { 5, "HP Pavilion Gaming 690-0007nc", 2 },
                    { 29, "ThinkPad T400", 1 },
                    { 28, "ThinkPad T480", 1 },
                    { 4, "ThinkPad X1 Carbon", 1 },
                    { 3, "Macbook Pro 15' 2015", 1 },
                    { 2, "Macbook Pro 13\" 2015", 1 },
                    { 26, "Windows 7 Pro", 6 },
                    { 27, "Microsoft Office 365", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProductId",
                table: "Questions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_QeustionId",
                table: "Resolutions",
                column: "QeustionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
