using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Testbed.Migrations
{
    public partial class FixedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BourbonRatings_Bourbons_BourbonId",
                table: "BourbonRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bourbons_Distilleries_DistilleryId",
                table: "Bourbons");

            migrationBuilder.AlterColumn<int>(
                name: "DistilleryId",
                table: "Bourbons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BourbonId",
                table: "BourbonRatings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BourbonRatings_Bourbons_BourbonId",
                table: "BourbonRatings",
                column: "BourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bourbons_Distilleries_DistilleryId",
                table: "Bourbons",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BourbonRatings_Bourbons_BourbonId",
                table: "BourbonRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bourbons_Distilleries_DistilleryId",
                table: "Bourbons");

            migrationBuilder.AlterColumn<int>(
                name: "DistilleryId",
                table: "Bourbons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BourbonId",
                table: "BourbonRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BourbonRatings_Bourbons_BourbonId",
                table: "BourbonRatings",
                column: "BourbonId",
                principalTable: "Bourbons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bourbons_Distilleries_DistilleryId",
                table: "Bourbons",
                column: "DistilleryId",
                principalTable: "Distilleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
