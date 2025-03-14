using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChucVu",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "AspNetUsers");
        }
    }
}
