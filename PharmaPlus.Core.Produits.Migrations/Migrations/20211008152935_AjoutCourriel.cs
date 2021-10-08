using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmaPlus.Core.Produits.Migrations.Migrations
{
    public partial class AjoutCourriel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Courriel",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courriel",
                table: "Employe");
        }
    }
}
