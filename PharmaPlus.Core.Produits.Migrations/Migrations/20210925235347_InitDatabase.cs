using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaPlus.Core.Produits.Migrations.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) // Install Microsoft.EntityFrameworkCore.Relational
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drug_code = table.Column<int>(type: "int", nullable: false),
                    Class_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drug_identification_number = table.Column<int>(type: "int", nullable: false),
                    Brand_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_of_ais = table.Column<int>(type: "int", nullable: false),
                    Ai_group_no = table.Column<int>(type: "int", nullable: false),
                    Company_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purchase_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sell_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ppa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Expiry_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produit_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_PictureId",
                table: "Produit",
                column: "PictureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
