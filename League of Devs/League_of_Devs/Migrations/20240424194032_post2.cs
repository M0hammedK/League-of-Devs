using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace League_of_Devs.Migrations
{
    public partial class post2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_accounts_AccountsId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "AccountsId",
                table: "posts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_AccountsId",
                table: "posts",
                newName: "IX_posts_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_accounts_AccountId",
                table: "posts",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_accounts_AccountId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "posts",
                newName: "AccountsId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_AccountId",
                table: "posts",
                newName: "IX_posts_AccountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_accounts_AccountsId",
                table: "posts",
                column: "AccountsId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
