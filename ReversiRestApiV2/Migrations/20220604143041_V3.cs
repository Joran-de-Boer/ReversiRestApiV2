using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReversiRestApiV2.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Spellen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Spellen",
                columns: new[] { "ID", "AandeBeurt", "Bord", "Omschrijving", "Speler1Token", "Speler2Token", "Token" },
                values: new object[] { 1, 1, "8883WB33BW3888", "Pablo", "Tra", "Tre", "Escobar1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spellen",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Spellen",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
