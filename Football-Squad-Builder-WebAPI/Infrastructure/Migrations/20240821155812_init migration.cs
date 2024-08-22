using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClubEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetitionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubEntity_CompetitionEntity_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "CompetitionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JerseyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalsThisSeason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistsThisSeason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClubId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerEntity_ClubEntity_ClubId",
                        column: x => x.ClubId,
                        principalTable: "ClubEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubEntity_CompetitionId",
                table: "ClubEntity",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEntity_ClubId",
                table: "PlayerEntity",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerEntity");

            migrationBuilder.DropTable(
                name: "ClubEntity");

            migrationBuilder.DropTable(
                name: "CompetitionEntity");
        }
    }
}
