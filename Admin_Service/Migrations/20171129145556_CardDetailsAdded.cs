using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Admin_Service.Migrations
{
    public partial class CardDetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditCardPermission",
                table: "CardDetails");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "CardDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_StaffID",
                table: "CardDetails",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDetails_Staff_StaffID",
                table: "CardDetails",
                column: "StaffID",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDetails_Staff_StaffID",
                table: "CardDetails");

            migrationBuilder.DropIndex(
                name: "IX_CardDetails_StaffID",
                table: "CardDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "CardDetails");

            migrationBuilder.AddColumn<bool>(
                name: "EditCardPermission",
                table: "CardDetails",
                nullable: false,
                defaultValue: false);
        }
    }
}
