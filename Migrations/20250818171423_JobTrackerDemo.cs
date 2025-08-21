using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAppTracker.Demo.Migrations
{
    /// <inheritdoc />
    public partial class JobTrackerDemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTrackerItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRefID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    JobApplicationStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTrackerItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTrackerItems");
        }
    }
}
