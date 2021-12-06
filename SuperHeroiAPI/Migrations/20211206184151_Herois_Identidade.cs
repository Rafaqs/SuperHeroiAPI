using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeroiAPI.Migrations
{
    public partial class Herois_Identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_identidadeSecretas_Herois_HeroiId",
                table: "identidadeSecretas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identidadeSecretas",
                table: "identidadeSecretas");

            migrationBuilder.RenameTable(
                name: "identidadeSecretas",
                newName: "IdentidadeSecreta");

            migrationBuilder.RenameIndex(
                name: "IX_identidadeSecretas_HeroiId",
                table: "IdentidadeSecreta",
                newName: "IX_IdentidadeSecreta_HeroiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentidadeSecreta",
                table: "IdentidadeSecreta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentidadeSecreta_Herois_HeroiId",
                table: "IdentidadeSecreta",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentidadeSecreta_Herois_HeroiId",
                table: "IdentidadeSecreta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentidadeSecreta",
                table: "IdentidadeSecreta");

            migrationBuilder.RenameTable(
                name: "IdentidadeSecreta",
                newName: "identidadeSecretas");

            migrationBuilder.RenameIndex(
                name: "IX_IdentidadeSecreta_HeroiId",
                table: "identidadeSecretas",
                newName: "IX_identidadeSecretas_HeroiId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_identidadeSecretas",
                table: "identidadeSecretas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_identidadeSecretas_Herois_HeroiId",
                table: "identidadeSecretas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
