using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymSis.Migrations
{
    /// <inheritdoc />
    public partial class addFKUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_IdGym",
                table: "Users",
                column: "IdGym");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gyms_IdGym",
                table: "Users",
                column: "IdGym",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gyms_IdGym",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdGym",
                table: "Users");
        }
    }
}
