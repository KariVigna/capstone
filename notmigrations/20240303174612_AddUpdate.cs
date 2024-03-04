using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    public partial class AddUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Kids_KidId",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kids",
                table: "Kids");

            migrationBuilder.RenameTable(
                name: "Kids",
                newName: "Kid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kid",
                table: "Kid",
                column: "KidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Kid_KidId",
                table: "Entries",
                column: "KidId",
                principalTable: "Kid",
                principalColumn: "KidId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Kid_KidId",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kid",
                table: "Kid");

            migrationBuilder.RenameTable(
                name: "Kid",
                newName: "Kids");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kids",
                table: "Kids",
                column: "KidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Kids_KidId",
                table: "Entries",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "KidId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
