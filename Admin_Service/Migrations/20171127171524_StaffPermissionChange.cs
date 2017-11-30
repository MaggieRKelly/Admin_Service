using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Admin_Service.Migrations
{
    public partial class StaffPermissionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPermission");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "EditCardPermission",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditInvPermission",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PurchasingPermission",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewCustMsgPermission",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditCardPermission",
                table: "CardDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditCardPermission",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "EditInvPermission",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PurchasingPermission",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ViewCustMsgPermission",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "EditCardPermission",
                table: "CardDetails");

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffPermission",
                columns: table => new
                {
                    StaffPermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardDetailsID = table.Column<int>(nullable: true),
                    CardID = table.Column<int>(nullable: false),
                    Permission = table.Column<int>(nullable: true),
                    StaffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPermission", x => x.StaffPermissionID);
                    table.ForeignKey(
                        name: "FK_StaffPermission_CardDetails_CardDetailsID",
                        column: x => x.CardDetailsID,
                        principalTable: "CardDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffPermission_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffPermission_CardDetailsID",
                table: "StaffPermission",
                column: "CardDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPermission_StaffID",
                table: "StaffPermission",
                column: "StaffID");
        }
    }
}
