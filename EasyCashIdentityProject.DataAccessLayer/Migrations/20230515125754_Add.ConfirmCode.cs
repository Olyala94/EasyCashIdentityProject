using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class AddConfirmCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID1",
                table: "CustomerAccounts");

            migrationBuilder.AddColumn<int>(
                name: "ConfirmCode",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmCode",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID1",
                table: "CustomerAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts",
                column: "CustomerAccountID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts",
                column: "CustomerAccountID1",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }
    }
}
