using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _28_WebAPI_Example.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rechnungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Zahl1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Zahl2 = table.Column<int>(type: "INTEGER", nullable: false),
                    op = table.Column<string>(type: "TEXT", nullable: false),
                    Ergebnis = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rechnungen", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rechnungen");
        }
    }
}
