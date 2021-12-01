using Microsoft.EntityFrameworkCore.Migrations;

namespace KameGameAPI.Migrations
{
    public partial class UnFixedCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shops_cards_cardModelCardId",
                table: "shops");

            migrationBuilder.DropIndex(
                name: "IX_shops_cardModelCardId",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "cardModelCardId",
                table: "shops");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "shops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cardModelCardId",
                table: "shops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shops_cardModelCardId",
                table: "shops",
                column: "cardModelCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_shops_cards_cardModelCardId",
                table: "shops",
                column: "cardModelCardId",
                principalTable: "cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
