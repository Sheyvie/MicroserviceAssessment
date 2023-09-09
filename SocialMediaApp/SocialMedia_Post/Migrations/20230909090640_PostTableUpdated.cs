using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia_Post.Migrations
{
    /// <inheritdoc />
    public partial class PostTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostHeaderId",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "PostHeaderId");
        }
    }
}
