using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Data.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "producersDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producersDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ticketDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventCode = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticketDbSet_clientDbSet_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCode = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventPrice = table.Column<int>(type: "int", nullable: false),
                    EventStatus = table.Column<bool>(type: "bit", nullable: false),
                    EventProducerId = table.Column<int>(type: "int", nullable: false),
                    EventProducerNmae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventDbSet_producersDbSet_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "producersDbSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventDbSet_ProducerId",
                table: "eventDbSet",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketDbSet_ClientId",
                table: "ticketDbSet",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventDbSet");

            migrationBuilder.DropTable(
                name: "ticketDbSet");

            migrationBuilder.DropTable(
                name: "producersDbSet");

            migrationBuilder.DropTable(
                name: "clientDbSet");
        }
    }
}
