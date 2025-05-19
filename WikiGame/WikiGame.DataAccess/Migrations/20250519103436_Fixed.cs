using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGame.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbLocationArmor");

            migrationBuilder.AlterColumn<string>(
                name: "SetId",
                table: "Armors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SetId",
                table: "Armors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DbLocationArmor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmorEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbLocationArmor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbLocationArmor_Armors_ArmorEntityId",
                        column: x => x.ArmorEntityId,
                        principalTable: "Armors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbLocationArmor_ArmorEntityId",
                table: "DbLocationArmor",
                column: "ArmorEntityId");
        }
    }
}
