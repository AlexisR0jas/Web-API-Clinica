using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class Genero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Pacientes");
        }
    }
}
