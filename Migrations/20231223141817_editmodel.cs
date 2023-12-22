using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationDemo.Migrations
{
    public partial class editmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e505cd47-7d8f-4198-a492-b9096652baae", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fadc33be-7f17-49de-880d-344ea3e9226b", "2", "Patient", "Patient" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a11ba6d3-7ad9-485e-95e2-fcb54e9a1005", "3", "Doctor", "Doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a11ba6d3-7ad9-485e-95e2-fcb54e9a1005");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e505cd47-7d8f-4198-a492-b9096652baae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fadc33be-7f17-49de-880d-344ea3e9226b");

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
    }
}
