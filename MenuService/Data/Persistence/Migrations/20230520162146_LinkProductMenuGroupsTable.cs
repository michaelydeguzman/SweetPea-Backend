using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuService.Migrations
{
    /// <inheritdoc />
    public partial class LinkProductMenuGroupsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_MenuGroupId",
                table: "Products",
                column: "MenuGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MenuGroups_MenuGroupId",
                table: "Products",
                column: "MenuGroupId",
                principalTable: "MenuGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MenuGroups_MenuGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MenuGroupId",
                table: "Products");
        }
    }
}
