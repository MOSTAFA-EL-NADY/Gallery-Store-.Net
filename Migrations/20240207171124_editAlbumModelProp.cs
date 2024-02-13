using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.Migrations
{
    /// <inheritdoc />
    public partial class editAlbumModelProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainImagery",
                table: "Albums",
                newName: "MainImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "Albums",
                newName: "MainImagery");
        }
    }
}
