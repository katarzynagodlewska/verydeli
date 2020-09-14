using Microsoft.EntityFrameworkCore.Migrations;

namespace VeryDeli.Data.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Addresses_AddressId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Addresses_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Addresses_AddressId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Addresses_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
