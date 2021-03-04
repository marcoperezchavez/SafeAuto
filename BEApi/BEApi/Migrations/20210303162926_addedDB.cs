using Microsoft.EntityFrameworkCore.Migrations;

namespace BEApi.Migrations
{
    public partial class addedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SafeAuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeAuto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationSafeAuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartTrip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EndTrip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Miles = table.Column<float>(type: "real", nullable: false),
                    SafeAutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationSafeAuto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationSafeAuto_SafeAuto_SafeAutoId",
                        column: x => x.SafeAutoId,
                        principalTable: "SafeAuto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationSafeAuto_SafeAutoId",
                table: "InformationSafeAuto",
                column: "SafeAutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationSafeAuto");

            migrationBuilder.DropTable(
                name: "SafeAuto");
        }
    }
}
