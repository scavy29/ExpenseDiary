using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseDiary.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseReports",
                table: "ExpenseReports");

            migrationBuilder.RenameTable(
                name: "ExpenseReports",
                newName: "Expenses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "ExpenseReports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseReports",
                table: "ExpenseReports",
                column: "ItemId");
        }
    }
}
