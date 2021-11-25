using Microsoft.EntityFrameworkCore.Migrations;

namespace KameGameAPI.Migrations
{
    public partial class cardFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_cards_CardId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CardId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cards_UserId",
                table: "cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_users_UserId",
                table: "cards");

            migrationBuilder.DropIndex(
                name: "IX_cards_UserId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cards");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_CardId",
                table: "users",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_cards_CardId",
                table: "users",
                column: "CardId",
                principalTable: "cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
