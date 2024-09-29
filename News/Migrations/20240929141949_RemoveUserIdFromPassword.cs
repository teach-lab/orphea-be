using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Migrations;

/// <inheritdoc />
public partial class RemoveUserIdFromPassword : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Password_UserEntity_UserId",
            table: "Password");

        migrationBuilder.DropIndex(
            name: "IX_Password_UserId",
            table: "Password");

        migrationBuilder.DropColumn(
            name: "UserId",
            table: "Password");

        migrationBuilder.CreateIndex(
            name: "IX_UserEntity_PasswordId",
            table: "UserEntity",
            column: "PasswordId",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_UserEntity_Password_PasswordId",
            table: "UserEntity",
            column: "PasswordId",
            principalTable: "Password",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_UserEntity_Password_PasswordId",
            table: "UserEntity");

        migrationBuilder.DropIndex(
            name: "IX_UserEntity_PasswordId",
            table: "UserEntity");

        migrationBuilder.AddColumn<Guid>(
            name: "UserId",
            table: "Password",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.CreateIndex(
            name: "IX_Password_UserId",
            table: "Password",
            column: "UserId",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Password_UserEntity_UserId",
            table: "Password",
            column: "UserId",
            principalTable: "UserEntity",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
