using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                LikeCount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Login = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Comments");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
