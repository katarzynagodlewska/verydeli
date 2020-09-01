using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeryDeli.Data.Migrations
{
    public partial class AddFoodTypesToFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodFoodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FoodTypeId = table.Column<int>(nullable: false),
                    FoodId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodFoodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodFoodTypes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodFoodTypes_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodFoodTypes_FoodId",
                table: "FoodFoodTypes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodFoodTypes_FoodTypeId",
                table: "FoodFoodTypes",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodFoodTypes");

            migrationBuilder.DropTable(
                name: "FoodTypes");
        }
    }
}
