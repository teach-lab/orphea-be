using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace News.Migrations;

/// <inheritdoc />
public partial class NullablePassworId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Users_Password_PasswordId",
            table: "Users");

        migrationBuilder.DropIndex(
            name: "IX_Users_PasswordId",
            table: "Users");

        migrationBuilder.AlterColumn<Guid>(
            name: "PasswordId",
            table: "Users",
            type: "uniqueidentifier",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.CreateIndex(
            name: "IX_Users_PasswordId",
            table: "Users",
            column: "PasswordId",
            unique: true,
            filter: "[PasswordId] IS NOT NULL");

        migrationBuilder.AddForeignKey(
            name: "FK_Users_Password_PasswordId",
            table: "Users",
            column: "PasswordId",
            principalTable: "Password",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Users_Password_PasswordId",
            table: "Users");

        migrationBuilder.DropIndex(
            name: "IX_Users_PasswordId",
            table: "Users");

        migrationBuilder.AlterColumn<Guid>(
            name: "PasswordId",
            table: "Users",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier",
            oldNullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Users_PasswordId",
            table: "Users",
            column: "PasswordId",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Users_Password_PasswordId",
            table: "Users",
            column: "PasswordId",
            principalTable: "Password",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
