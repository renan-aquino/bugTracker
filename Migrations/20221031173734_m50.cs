using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bugTracker.Migrations
{
    public partial class m50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Historico",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutorId",
                table: "Historico",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AutorNome",
                table: "Historico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grau",
                table: "Historico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Historico",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Historico_AutorId",
                table: "Historico",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_TicketID",
                table: "Historico",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_AspNetUsers_AutorId",
                table: "Historico",
                column: "AutorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Tickets_TicketID",
                table: "Historico",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_AspNetUsers_AutorId",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Tickets_TicketID",
                table: "Historico");

            migrationBuilder.DropIndex(
                name: "IX_Historico_AutorId",
                table: "Historico");

            migrationBuilder.DropIndex(
                name: "IX_Historico_TicketID",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "AutorNome",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Grau",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Historico");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Historico",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
