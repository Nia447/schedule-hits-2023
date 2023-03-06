using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAttributeInfinityInLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infinity",
                table: "Lessons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Infinity",
                table: "Lessons",
                type: "bit",
                nullable: true);
        }
    }
}
