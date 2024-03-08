using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    public partial class AddUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Kids_KidId",
                table: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Prizes_KidId",
                table: "Prizes");

            migrationBuilder.DropColumn(
                name: "KidId",
                table: "Prizes");

            migrationBuilder.CreateTable(
                name: "KidPrizes",
                columns: table => new
                {
                    KidPrizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KidId = table.Column<int>(type: "int", nullable: false),
                    PrizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KidPrizes", x => x.KidPrizeId);
                    table.ForeignKey(
                        name: "FK_KidPrizes_Kids_KidId",
                        column: x => x.KidId,
                        principalTable: "Kids",
                        principalColumn: "KidId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KidPrizes_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "PrizeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_KidPrizes_KidId",
                table: "KidPrizes",
                column: "KidId");

            migrationBuilder.CreateIndex(
                name: "IX_KidPrizes_PrizeId",
                table: "KidPrizes",
                column: "PrizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KidPrizes");

            migrationBuilder.AddColumn<int>(
                name: "KidId",
                table: "Prizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_KidId",
                table: "Prizes",
                column: "KidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Kids_KidId",
                table: "Prizes",
                column: "KidId",
                principalTable: "Kids",
                principalColumn: "KidId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
