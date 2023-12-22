using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationDemo.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "81a7e3a8-130b-4359-ae0a-df70b9b7167f", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "917bb78b-ad47-471a-b123-065eb0bd19c0", "2", "Patient", "Patient" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d64ad0f3-07b0-4177-8b6c-1c6a6c7eb553", "3", "Doctor", "Doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a7e3a8-130b-4359-ae0a-df70b9b7167f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "917bb78b-ad47-471a-b123-065eb0bd19c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64ad0f3-07b0-4177-8b6c-1c6a6c7eb553");

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
    }
}
