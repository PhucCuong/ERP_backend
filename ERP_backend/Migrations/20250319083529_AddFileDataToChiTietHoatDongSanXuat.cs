using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFileDataToChiTietHoatDongSanXuat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "ChiTietHoatDongSanXuat",
                type: "VARBINARY(MAX)",
                nullable: true);

       
          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "ChiTietHoatDongSanXuat");

           
        }
    }
}
