using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schedule.Migrations
{
    /// <inheritdoc />
    public partial class AddedAudienceInLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AudienceId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AudienceId",
                table: "Lessons",
                column: "AudienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Audiences_AudienceId",
                table: "Lessons",
                column: "AudienceId",
                principalTable: "Audiences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Audiences_AudienceId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_AudienceId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "AudienceId",
                table: "Lessons");
        }
    }
}
