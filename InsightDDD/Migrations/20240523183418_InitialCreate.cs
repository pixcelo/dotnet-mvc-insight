using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightDDD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaDetail",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    caption = table.Column<string>(type: "TEXT", nullable: false),
                    likeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    mediaUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDetail", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaDetail");
        }
    }
}
