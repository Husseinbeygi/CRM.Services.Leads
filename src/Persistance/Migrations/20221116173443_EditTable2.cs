using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class EditTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "--None--" });

            migrationBuilder.InsertData(
                table: "LeadSources",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "--None--" });

            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "--None--" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Value",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 0);
        }
    }
}
