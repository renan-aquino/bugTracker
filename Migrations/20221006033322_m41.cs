using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bugTracker.Migrations
{
    public partial class m41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projetos_ProjectModelID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjectModelID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ProjectModelID",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjetoID",
                table: "Tickets",
                column: "ProjetoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projetos_ProjetoID",
                table: "Tickets",
                column: "ProjetoID",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projetos_ProjetoID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ProjetoID",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelID",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectModelID",
                table: "Tickets",
                column: "ProjectModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projetos_ProjectModelID",
                table: "Tickets",
                column: "ProjectModelID",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
