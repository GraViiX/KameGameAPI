using Microsoft.EntityFrameworkCore.Migrations;

namespace KameGameAPI.Migrations
{
    public partial class propFail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shops_users_userModelUserId",
                table: "shops");

            migrationBuilder.DropIndex(
                name: "IX_shops_userModelUserId",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "userModelUserId",
                table: "shops");

            migrationBuilder.CreateIndex(
                name: "IX_shops_UserId",
                table: "shops",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shops_users_UserId",
                table: "shops",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shops_users_UserId",
                table: "shops");

            migrationBuilder.DropIndex(
                name: "IX_shops_UserId",
                table: "shops");

            migrationBuilder.AddColumn<int>(
                name: "userModelUserId",
                table: "shops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shops_userModelUserId",
                table: "shops",
                column: "userModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shops_users_userModelUserId",
                table: "shops",
                column: "userModelUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
