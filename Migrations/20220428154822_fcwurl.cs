using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hydrants.net_2022.Migrations
{
    public partial class fcwurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "FetchRecords",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "FetchRecords");
        }
    }
}
