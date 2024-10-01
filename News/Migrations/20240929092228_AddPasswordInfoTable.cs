using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations;

/// <inheritdoc />
public partial class AddPasswordInfoTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Password",
            table: "UserEntity");

        migrationBuilder.DropColumn(
            name: "Salt",
            table: "UserEntity");

        migrationBuilder.AddColumn<Guid>(
            name: "PasswordId",
            table: "UserEntity",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.CreateTable(
            name: "Password",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Password", x => x.Id);
                table.ForeignKey(
                    name: "FK_Password_UserEntity_UserId",
                    column: x => x.UserId,
                    principalTable: "UserEntity",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Password_UserId",
            table: "Password",
            column: "UserId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Password");

        migrationBuilder.DropColumn(
            name: "PasswordId",
            table: "UserEntity");

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "UserEntity",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "Salt",
            table: "UserEntity",
            type: "varbinary(max)",
            nullable: true);
    }
}
