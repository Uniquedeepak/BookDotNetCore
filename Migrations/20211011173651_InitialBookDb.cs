using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksMicroservice.Migrations
{
    public partial class InitialBookDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(maxLength: 13, nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublicationDate", "Title" },
                values: new object[] { 1, "xyz", "0074625421", new DateTime(2015, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublicationDate", "Title" },
                values: new object[] { 2, "abc", "0074625422", new DateTime(2015, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "c#" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublicationDate", "Title" },
                values: new object[] { 3, "123", "0074625423", new DateTime(2015, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Python" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
