using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoyageID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VoyageID",
                table: "Tickets",
                column: "VoyageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Voyages_VoyageID",
                table: "Tickets",
                column: "VoyageID",
                principalTable: "Voyages",
                principalColumn: "VoyageID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Voyages_VoyageID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_VoyageID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "VoyageID",
                table: "Tickets");
        }
    }
}
