using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingTickets.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenamedLoginUserToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "login",
                table: "users",
                newName: "salt");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "salt",
                table: "users",
                newName: "login");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
