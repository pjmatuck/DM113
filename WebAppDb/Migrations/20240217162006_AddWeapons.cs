using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDb.Migrations
{
    /// <inheritdoc />
    public partial class AddWeapons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Players",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Players",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Players",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "id");
        }
    }
}
