using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEstudiante.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    estudianteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombresEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidosEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCurso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.estudianteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
