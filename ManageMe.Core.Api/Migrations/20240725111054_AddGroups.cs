using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageMe.Core.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_GroupId",
                table: "Applicants",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Groups_GroupId",
                table: "Applicants",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Groups_GroupId",
                table: "Applicants");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_GroupId",
                table: "Applicants");
        }
    }
}
