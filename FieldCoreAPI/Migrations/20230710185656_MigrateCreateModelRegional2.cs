using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldCoreAPI.Migrations
{
    public partial class MigrateCreateModelRegional2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Regionais_RegionalId",
                table: "Unidades");

            migrationBuilder.AlterColumn<int>(
                name: "RegionalId",
                table: "Unidades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Regionais_RegionalId",
                table: "Unidades",
                column: "RegionalId",
                principalTable: "Regionais",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Regionais_RegionalId",
                table: "Unidades");

            migrationBuilder.AlterColumn<int>(
                name: "RegionalId",
                table: "Unidades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Regionais_RegionalId",
                table: "Unidades",
                column: "RegionalId",
                principalTable: "Regionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
