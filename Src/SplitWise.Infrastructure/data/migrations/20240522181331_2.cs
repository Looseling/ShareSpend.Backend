using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareSpend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Users_AdminId",
                table: "Containers");

            migrationBuilder.DropIndex(
                name: "IX_Containers_AdminId",
                table: "Containers");

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Containers_AdminId",
                table: "Containers",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Users_AdminId",
                table: "Containers",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}