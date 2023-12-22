using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationDemo.Migrations
{
    public partial class AddingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0b9966c-b103-4a5d-84e0-6ad16cbdf13f", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "912a2bf7-9179-4324-9ba0-b3d75cb5f380", "2", "Patient", "Patient" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "152b2a59-9c51-465b-aec7-086d69e6af8e", "3", "Doctor", "Doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152b2a59-9c51-465b-aec7-086d69e6af8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "912a2bf7-9179-4324-9ba0-b3d75cb5f380");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b9966c-b103-4a5d-84e0-6ad16cbdf13f");
        }
    }
}
