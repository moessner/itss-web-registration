using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class groupseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorisierungsCode",
                table: "Group");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizationCode",
                table: "Group",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "AuthorizationCode", "Name" },
                values: new object[] { 1, "258A52FS", "Customer" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "AuthorizationCode", "Name" },
                values: new object[] { 2, "10AL29S5", "Premium Customer" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "GroupId", "AuthorizationCode", "Name" },
                values: new object[] { 3, "4829ASK1", "Interested" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "GroupId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AuthorizationCode",
                table: "Group");

            migrationBuilder.AddColumn<string>(
                name: "AuthorisierungsCode",
                table: "Group",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
