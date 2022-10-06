using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bugTracker.Migrations
{
    public partial class m39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tickets_TicketID",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Tickets_TicketID",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projetos_ProjetoID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjetoID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Historico_TicketID",
                table: "Historico");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_TicketID",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelID",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketModelID",
                table: "Historico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketModelID",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectModelID",
                table: "Tickets",
                column: "ProjectModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_TicketModelID",
                table: "Historico",
                column: "TicketModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TicketModelID",
                table: "Comentarios",
                column: "TicketModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tickets_TicketModelID",
                table: "Comentarios",
                column: "TicketModelID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Tickets_TicketModelID",
                table: "Historico",
                column: "TicketModelID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projetos_ProjectModelID",
                table: "Tickets",
                column: "ProjectModelID",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Tickets_TicketModelID",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Tickets_TicketModelID",
                table: "Historico");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projetos_ProjectModelID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectModelID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Historico_TicketModelID",
                table: "Historico");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_TicketModelID",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "ProjectModelID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketModelID",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "TicketModelID",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoID",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjetoID",
                table: "Tickets",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_TicketID",
                table: "Historico",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TicketID",
                table: "Comentarios",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Tickets_TicketID",
                table: "Comentarios",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Tickets_TicketID",
                table: "Historico",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projetos_ProjetoID",
                table: "Tickets",
                column: "ProjetoID",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
