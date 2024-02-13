using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.Migrations
{
    /// <inheritdoc />
    public partial class editAlbumModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImagery",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImagery",
                table: "Albums");
        }
    }
}
