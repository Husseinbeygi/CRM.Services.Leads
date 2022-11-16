using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class EditTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Value", "Name" },
                values: new object[] { 31, "Agriculture" });

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 1,
                column: "Name",
                value: "Advertisement");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 2,
                column: "Name",
                value: "External Referral");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "In-Store");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 4,
                column: "Name",
                value: "On Site");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 5,
                column: "Name",
                value: "Social");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 6,
                column: "Name",
                value: "Web");

            migrationBuilder.InsertData(
                table: "LeadSources",
                columns: new[] { "Value", "Name" },
                values: new object[] { 7, "Word of mouth" });

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 1,
                column: "Name",
                value: "Mr.");

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 2,
                column: "Name",
                value: "Ms.");

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "Dr.");

            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Value", "Name" },
                values: new object[] { 4, "Prof." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Value",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "Agriculture" });

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 1,
                column: "Name",
                value: "External Referral");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 2,
                column: "Name",
                value: "In-Store");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "On Site");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 4,
                column: "Name",
                value: "Social");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 5,
                column: "Name",
                value: "Web");

            migrationBuilder.UpdateData(
                table: "LeadSources",
                keyColumn: "Value",
                keyValue: 6,
                column: "Name",
                value: "Word of mouth");

            migrationBuilder.InsertData(
                table: "LeadSources",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "Advertisement" });

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 1,
                column: "Name",
                value: "Ms.");

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 2,
                column: "Name",
                value: "Dr.");

            migrationBuilder.UpdateData(
                table: "Salutations",
                keyColumn: "Value",
                keyValue: 3,
                column: "Name",
                value: "Prof.");

            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Value", "Name" },
                values: new object[] { 0, "Mr." });
        }
    }
}
