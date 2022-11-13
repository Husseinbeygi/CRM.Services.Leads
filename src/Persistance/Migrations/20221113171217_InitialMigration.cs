using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "LeadSources",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSources", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "LeadStatuses",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadStatuses", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Salutations",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salutations", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalutationId = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadStatusId = table.Column<int>(type: "int", nullable: true),
                    AnnualRevenue = table.Column<decimal>(type: "decimal(2,2)", precision: 2, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IndustryId = table.Column<int>(type: "int", nullable: true),
                    LeadSourceId = table.Column<int>(type: "int", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RatingId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Value");
                    table.ForeignKey(
                        name: "FK_Leads_LeadSources_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalTable: "LeadSources",
                        principalColumn: "Value");
                    table.ForeignKey(
                        name: "FK_Leads_LeadStatuses_LeadStatusId",
                        column: x => x.LeadStatusId,
                        principalTable: "LeadStatuses",
                        principalColumn: "Value");
                    table.ForeignKey(
                        name: "FK_Leads_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Value");
                    table.ForeignKey(
                        name: "FK_Leads_Salutations_SalutationId",
                        column: x => x.SalutationId,
                        principalTable: "Salutations",
                        principalColumn: "Value");
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 0, "Agriculture" },
                    { 1, "Apparel" },
                    { 2, "Banking" },
                    { 3, "Biotechnology" },
                    { 4, "Chemicals" },
                    { 5, "Communications" },
                    { 6, "Construction" },
                    { 7, "Consulting" },
                    { 8, "Education" },
                    { 9, "Electronics" },
                    { 10, "Energy" },
                    { 11, "Engineering" },
                    { 12, "Entertainment" },
                    { 13, "Environmental" },
                    { 14, "Finance" },
                    { 15, "Government" },
                    { 16, "Healthcare" },
                    { 17, "Hospitality" },
                    { 18, "Insurance" },
                    { 19, "Machinery" },
                    { 20, "Media" },
                    { 21, "Not For Profit" },
                    { 22, "Retail" },
                    { 23, "Shipping" },
                    { 24, "Technology" },
                    { 25, "Telecommunications" },
                    { 26, "Transportation" },
                    { 27, "Utilities" },
                    { 28, "Recreation" },
                    { 29, "Manufacturing" },
                    { 30, "Other" }
                });

            migrationBuilder.InsertData(
                table: "LeadSources",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 0, "Advertisement" },
                    { 1, "External Referral" },
                    { 2, "In-Store" },
                    { 3, "On Site" },
                    { 4, "Social" },
                    { 5, "Web" },
                    { 6, "Word of mouth" }
                });

            migrationBuilder.InsertData(
                table: "LeadStatuses",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 0, "New" },
                    { 1, "Contacted" },
                    { 2, "Working" },
                    { 3, "Qualified" }
                });

            migrationBuilder.InsertData(
                table: "LeadStatuses",
                columns: new[] { "Value", "Name" },
                values: new object[] { 4, "Unqualified" });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 0, "Cold" },
                    { 1, "Warm" },
                    { 2, "Hot" }
                });

            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Value", "Name" },
                values: new object[,]
                {
                    { 0, "Mr." },
                    { 1, "Ms." },
                    { 2, "Dr." },
                    { 3, "Prof." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_IndustryId",
                table: "Leads",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadSourceId",
                table: "Leads",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadStatusId",
                table: "Leads",
                column: "LeadStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_RatingId",
                table: "Leads",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SalutationId",
                table: "Leads",
                column: "SalutationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "LeadSources");

            migrationBuilder.DropTable(
                name: "LeadStatuses");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Salutations");
        }
    }
}
