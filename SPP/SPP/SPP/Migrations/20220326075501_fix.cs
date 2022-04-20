using Microsoft.EntityFrameworkCore.Migrations;

namespace SPP.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastNameName",
                table: "Clients",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "LastNameName");
        }
    }
}
