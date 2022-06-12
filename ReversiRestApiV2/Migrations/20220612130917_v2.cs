using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReversiRestApiV2.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spellen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speler1Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speler2Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AandeBeurt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spellen", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Spellen",
                columns: new[] { "ID", "AandeBeurt", "Bord", "Omschrijving", "Speler1Token", "Speler2Token", "Token" },
                values: new object[] { 1, 1, "8883WB33BW3888", "Pablo", "Tra", "Tre", "Escobar1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spellen");
        }
    }
}
