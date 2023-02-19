using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCounterDataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCategoryEntityTable",
                columns: table => new
                {
                    FoodCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategoryEntityTable", x => x.FoodCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "MealCategoryEntityTable",
                columns: table => new
                {
                    MealCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategoryEntityTable", x => x.MealCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "PhotographEntityTable",
                columns: table => new
                {
                    PhotographID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotographName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photograph = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographEntityTable", x => x.PhotographID);
                });

            migrationBuilder.CreateTable(
                name: "UserEntityTable",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserHeight = table.Column<int>(type: "int", nullable: true),
                    UserWeight = table.Column<int>(type: "int", nullable: true),
                    UserGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserState = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntityTable", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "FoodEntityTable",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodCategoryID = table.Column<int>(type: "int", nullable: true),
                    PhotographID = table.Column<int>(type: "int", nullable: true),
                    FoodCalorie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEntityTable", x => x.FoodID);
                    table.ForeignKey(
                        name: "FK_FoodEntityTable_FoodCategoryEntityTable_FoodCategoryID",
                        column: x => x.FoodCategoryID,
                        principalTable: "FoodCategoryEntityTable",
                        principalColumn: "FoodCategoryID");
                    table.ForeignKey(
                        name: "FK_FoodEntityTable_PhotographEntityTable_PhotographID",
                        column: x => x.PhotographID,
                        principalTable: "PhotographEntityTable",
                        principalColumn: "PhotographID");
                });

            migrationBuilder.CreateTable(
                name: "MealEntityTable",
                columns: table => new
                {
                    MealID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealCategoryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    FoodPortion = table.Column<int>(type: "int", nullable: false),
                    FoodTotalCalorie = table.Column<int>(type: "int", nullable: false),
                    MealTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealEntityTable", x => x.MealID);
                    table.ForeignKey(
                        name: "FK_MealEntityTable_FoodEntityTable_FoodID",
                        column: x => x.FoodID,
                        principalTable: "FoodEntityTable",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealEntityTable_MealCategoryEntityTable_MealCategoryID",
                        column: x => x.MealCategoryID,
                        principalTable: "MealCategoryEntityTable",
                        principalColumn: "MealCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealEntityTable_UserEntityTable_UserID",
                        column: x => x.UserID,
                        principalTable: "UserEntityTable",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntityTable_FoodCategoryID",
                table: "FoodEntityTable",
                column: "FoodCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntityTable_PhotographID",
                table: "FoodEntityTable",
                column: "PhotographID");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntityTable_FoodID",
                table: "MealEntityTable",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntityTable_MealCategoryID",
                table: "MealEntityTable",
                column: "MealCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntityTable_UserID",
                table: "MealEntityTable",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealEntityTable");

            migrationBuilder.DropTable(
                name: "FoodEntityTable");

            migrationBuilder.DropTable(
                name: "MealCategoryEntityTable");

            migrationBuilder.DropTable(
                name: "UserEntityTable");

            migrationBuilder.DropTable(
                name: "FoodCategoryEntityTable");

            migrationBuilder.DropTable(
                name: "PhotographEntityTable");
        }
    }
}
