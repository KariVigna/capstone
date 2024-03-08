using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    public partial class AddDbSetPrizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prize_Kids_KidId",
                table: "Prize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prize",
                table: "Prize");

            migrationBuilder.RenameTable(
                name: "Prize",
                newName: "Prizes");

            migrationBuilder.RenameIndex(
                name: "IX_Prize_KidId",
                table: "Prizes",
                newName: "IX_Prizes_KidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Kids_KidId",
                table: "Prizes",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "KidId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Kids_KidId",
                table: "Prizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes");

            migrationBuilder.RenameTable(
                name: "Prizes",
                newName: "Prize");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_KidId",
                table: "Prize",
                newName: "IX_Prize_KidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prize",
                table: "Prize",
                column: "PrizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prize_Kids_KidId",
                table: "Prize",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "KidId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
