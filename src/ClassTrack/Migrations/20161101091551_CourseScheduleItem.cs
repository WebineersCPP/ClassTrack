using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassTrack.Migrations
{
    public partial class CourseScheduleItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassNumber",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseItemId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndTime",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructor",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartTime",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CourseItemId",
                table: "Item",
                column: "CourseItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Item_CourseItemId",
                table: "Item",
                column: "CourseItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Item_CourseItemId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CourseItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CourseItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Instructor",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Item");
        }
    }
}
