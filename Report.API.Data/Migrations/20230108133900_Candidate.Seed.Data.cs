using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Report.API.Data.Migrations
{
    public partial class CandidateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidate",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3190d79f-b975-4f60-9f30-0b7e2c3a1eb6"), new DateTime(2023, 1, 8, 16, 39, 0, 510, DateTimeKind.Local).AddTicks(2933), true, "Candidate 1", null },
                    { new Guid("d733adcf-45ad-4029-98b1-a4d269f39872"), new DateTime(2023, 1, 8, 16, 39, 0, 511, DateTimeKind.Local).AddTicks(904), true, "Candidate 2", null },
                    { new Guid("5af7c85e-f941-4080-afc4-185852172d1b"), new DateTime(2023, 1, 8, 16, 39, 0, 511, DateTimeKind.Local).AddTicks(932), true, "Candidate 3", null },
                    { new Guid("a31a3514-9414-49be-b361-47be256e831e"), new DateTime(2023, 1, 8, 16, 39, 0, 511, DateTimeKind.Local).AddTicks(934), true, "Candidate 4", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidate",
                keyColumn: "Id",
                keyValue: new Guid("3190d79f-b975-4f60-9f30-0b7e2c3a1eb6"));

            migrationBuilder.DeleteData(
                table: "Candidate",
                keyColumn: "Id",
                keyValue: new Guid("5af7c85e-f941-4080-afc4-185852172d1b"));

            migrationBuilder.DeleteData(
                table: "Candidate",
                keyColumn: "Id",
                keyValue: new Guid("a31a3514-9414-49be-b361-47be256e831e"));

            migrationBuilder.DeleteData(
                table: "Candidate",
                keyColumn: "Id",
                keyValue: new Guid("d733adcf-45ad-4029-98b1-a4d269f39872"));
        }
    }
}