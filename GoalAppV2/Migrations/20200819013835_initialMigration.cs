using Microsoft.EntityFrameworkCore.Migrations;

namespace GoalAppV2.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "A seeded note to test the concept", "The first seed note" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Note body for note 2", "The second seed note" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
