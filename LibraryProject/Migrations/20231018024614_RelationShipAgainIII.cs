using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Migrations
{
    /// <inheritdoc />
    public partial class RelationShipAgainIII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_LibraryBranch_LibraryBranchId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LibraryBranchId",
                table: "Book");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Book_LibraryBranchId",
                table: "Book",
                column: "LibraryBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_LibraryBranch_LibraryBranchId",
                table: "Book",
                column: "LibraryBranchId",
                principalTable: "LibraryBranch",
                principalColumn: "LibraryBranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
