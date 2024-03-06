using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CompanyID",
                table: "Messages",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_CompanyID",
                table: "Messages",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_CompanyID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CompanyID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Messages");
        }
    }
}
