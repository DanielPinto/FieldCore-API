using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldCoreAPI.Migrations
{
    public partial class RelacionalUsersUnidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadeModelUserModel",
                columns: table => new
                {
                    UnidadesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeModelUserModel", x => new { x.UnidadesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UnidadeModelUserModel_Unidades_UnidadesId",
                        column: x => x.UnidadesId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnidadeModelUserModel_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeModelUserModel_UsersId",
                table: "UnidadeModelUserModel",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadeModelUserModel");
        }
    }
}
