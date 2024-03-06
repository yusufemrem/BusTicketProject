using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class app_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppUserID",
                table: "Tickets",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserID",
                table: "Tickets",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AppUserID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "AspNetUsers");
        }
    }
}
