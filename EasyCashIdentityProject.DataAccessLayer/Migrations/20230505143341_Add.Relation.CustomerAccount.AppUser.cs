using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashIdentityProject.DataAccessLayer.Migrations
{
    public partial class AddRelationCustomerAccountAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CustomerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID1",
                table: "CustomerAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts",
                column: "CustomerAccountID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts",
                column: "CustomerAccountID1",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID1",
                table: "CustomerAccounts");
        }
    }
}
