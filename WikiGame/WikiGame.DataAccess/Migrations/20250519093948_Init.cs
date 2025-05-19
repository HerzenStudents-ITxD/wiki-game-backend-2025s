using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WikiGame.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbLocationArmor");

            migrationBuilder.DropTable(
                name: "Armors");
        }
    }
}
