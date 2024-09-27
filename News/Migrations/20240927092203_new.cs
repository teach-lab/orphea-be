using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations;

/// <inheritdoc />
public partial class @new : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Password",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Email",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.CreateTable(
            name: "Publishers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TrustScore = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Publishers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Articles",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                TrustScore = table.Column<int>(type: "int", nullable: false),
                PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Articles", x => x.Id);
                table.ForeignKey(
                    name: "FK_Articles_Publishers_PublisherId",
                    column: x => x.PublisherId,
                    principalTable: "Publishers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ArticleTags",
            columns: table => new
            {
                ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                table.ForeignKey(
                    name: "FK_ArticleTags_Articles_ArticleId",
                    column: x => x.ArticleId,
                    principalTable: "Articles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ArticleTags_Tags_TagId",
                    column: x => x.TagId,
                    principalTable: "Tags",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Comments_UserId",
            table: "Comments",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Articles_PublisherId",
            table: "Articles",
            column: "PublisherId");

        migrationBuilder.CreateIndex(
            name: "IX_ArticleTags_TagId",
            table: "ArticleTags",
            column: "TagId");

        migrationBuilder.AddForeignKey(
            name: "FK_Comments_Users_UserId",
            table: "Comments",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Comments_Users_UserId",
            table: "Comments");

        migrationBuilder.DropTable(
            name: "ArticleTags");

        migrationBuilder.DropTable(
            name: "Articles");

        migrationBuilder.DropTable(
            name: "Tags");

        migrationBuilder.DropTable(
            name: "Publishers");

        migrationBuilder.DropIndex(
            name: "IX_Comments_UserId",
            table: "Comments");

        migrationBuilder.AlterColumn<string>(
            name: "Password",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Email",
            table: "Users",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);
    }
}
