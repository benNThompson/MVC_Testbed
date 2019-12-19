using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Testbed.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distilleries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distilleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bourbons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistilleryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bourbons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bourbons_Distilleries_DistilleryId",
                        column: x => x.DistilleryId,
                        principalTable: "Distilleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BourbonRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BourbonId = table.Column<int>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    TastingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BourbonRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BourbonRatings_Bourbons_BourbonId",
                        column: x => x.BourbonId,
                        principalTable: "Bourbons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BourbonRatings_BourbonId",
                table: "BourbonRatings",
                column: "BourbonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bourbons_DistilleryId",
                table: "Bourbons",
                column: "DistilleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BourbonRatings");

            migrationBuilder.DropTable(
                name: "Bourbons");

            migrationBuilder.DropTable(
                name: "Distilleries");
        }
    }
}
