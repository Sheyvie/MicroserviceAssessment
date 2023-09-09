using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia_Post.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "Posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "PostHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Posts",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "PostHeaderId",
                table: "Posts",
                newName: "PostId");
        }
    }
}
