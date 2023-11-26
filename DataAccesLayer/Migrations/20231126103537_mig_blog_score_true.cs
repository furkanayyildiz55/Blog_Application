using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_blog_score_true : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
