using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Data.Migrations
{
    public partial class one_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticketDbSet_eventDbSet_SingleEventId",
                table: "ticketDbSet");

            migrationBuilder.DropIndex(
                name: "IX_ticketDbSet_SingleEventId",
                table: "ticketDbSet");

            migrationBuilder.DropColumn(
                name: "SingleEventId",
                table: "ticketDbSet");

            migrationBuilder.CreateIndex(
                name: "IX_ticketDbSet_EventId",
                table: "ticketDbSet",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticketDbSet_eventDbSet_EventId",
                table: "ticketDbSet",
                column: "EventId",
                principalTable: "eventDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticketDbSet_eventDbSet_EventId",
                table: "ticketDbSet");

            migrationBuilder.DropIndex(
                name: "IX_ticketDbSet_EventId",
                table: "ticketDbSet");

            migrationBuilder.AddColumn<int>(
                name: "SingleEventId",
                table: "ticketDbSet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticketDbSet_SingleEventId",
                table: "ticketDbSet",
                column: "SingleEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticketDbSet_eventDbSet_SingleEventId",
                table: "ticketDbSet",
                column: "SingleEventId",
                principalTable: "eventDbSet",
                principalColumn: "Id");
        }
    }
}
