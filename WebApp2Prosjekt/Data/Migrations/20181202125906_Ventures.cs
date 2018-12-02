using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp2Prosjekt.Data.Migrations
{
    public partial class Ventures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_SpecialityFields_SpecialityFieldId",
                table: "Profiles");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialityFieldId",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_SpecialityFields_SpecialityFieldId",
                table: "Profiles",
                column: "SpecialityFieldId",
                principalTable: "SpecialityFields",
                principalColumn: "SpecialityFieldId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_SpecialityFields_SpecialityFieldId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialityFieldId",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_SpecialityFields_SpecialityFieldId",
                table: "Profiles",
                column: "SpecialityFieldId",
                principalTable: "SpecialityFields",
                principalColumn: "SpecialityFieldId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
