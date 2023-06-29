using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LifeDesignerOnAvalonia.Migrations
{
    /// <inheritdoc />
    public partial class UserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_IdUser",
                table: "Data",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdUser",
                table: "Category",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_UserLogin_IdUser",
                table: "Category",
                column: "IdUser",
                principalTable: "UserLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_UserLogin_IdUser",
                table: "Data",
                column: "IdUser",
                principalTable: "UserLogin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_UserLogin_IdUser",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_UserLogin_IdUser",
                table: "Data");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropIndex(
                name: "IX_Data_IdUser",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Category_IdUser",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Category");
        }
    }
}
