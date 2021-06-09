using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                //A continuacion tenemos la definicion de las tablas
                name: "Especialidad",
                columns: table => new
                {
                    idEspecialidad = table.Column<int>(nullable: false)
                    //Lo siguiente indica que cada elemento en la base va a incrementarse uno en uno
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //Lo siguiente indica que la descripcion puede ser opcional
                    Descripcion = table.Column<string>(nullable: true)
                },
                //Lo siguiente son las primary key
                constraints: table =>
                {
                    //Si vamos al modelo Especialidad.cs vamos a ver como toma el key que definimos de idEspecialidad.
                    table.PrimaryKey("PK_Especialidad", x => x.idEspecialidad);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidad");
        }
    }
}
