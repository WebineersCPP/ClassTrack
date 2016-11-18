using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassTrack.Migrations
{
    public partial class CPPMajorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPPMajor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPPMajor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPPSubplan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPPMajorId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPPSubplan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPPSubplan_CPPMajor_CPPMajorId",
                        column: x => x.CPPMajorId,
                        principalTable: "CPPMajor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPPSubplan_CPPMajorId",
                table: "CPPSubplan",
                column: "CPPMajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPPSubplan");

            migrationBuilder.DropTable(
                name: "CPPMajor");
        }
    }
}
