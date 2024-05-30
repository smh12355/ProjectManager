using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class push_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Cipher", "Name" },
                values: new object[,]
                {
                    { 1, "PRJ001", "Project Alpha" },
                    { 2, "PRJ002", "Project Beta" },
                    { 3, null, null },
                    { 4, null, null }
                });

            // Adding sample data to DesignObjectEntity
            migrationBuilder.InsertData(
                table: "DesignObjects",
                columns: new[] { "Id", "ProjectId", "ParentDesignObjectId", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "DO001", "Design Object 1 - first layer" },
                    { 2, 1, 1, "DO002", "Design Object 2 - second layer" },
                    { 3, 1, 1, "DO003", "Design Object 3 - second layer" },
                    { 4, 1, 2, "DO004", "Design Object 4 - third layer" },
                    { 5, 1, 2, "DO005", "Design Object 5 - third layer" },
                    { 6, 1, 3, "DO006", "Design Object 6 - third layer" },
                    { 7, 1, 3, "DO007", "Design Object 7 - third layer" },
                    { 8, 2, null, "DO008", "Design Object 8 - first layer" },
                    { 9, 2, 8, "DO009", "Design Object 9 - second layer" },
                    { 10, 2, 8, "DO010", "Design Object 10 - second layer" },
                    { 11, 2, 9, "DO011", "Design Object 11 - third layer" },
                    { 12, 2, 9, "DO012", "Design Object 12 - third layer" },
                    { 13, 2, 10, "DO013", "Design Object 13 - third layer" },
                    { 14, 2, 10, null, null },
                    { 15, null, null, null, null }
                });

            // Updating sample data in DocSetEntity
            migrationBuilder.InsertData(
                table: "DocSets",
                columns: new[] { "Id", "DesignObjectId", "Mark", "Number" },
                values: new object[,]
                {
                    { 1, 1, "TX", 0 },
                    { 2, 1, "AC", 1 },
                    { 3, 1, "CM", 2 },
                    { 4, 2, "TX", 0 },
                    { 5, 2, "AC", 1 },
                    { 6, 2, "CM", 2 },
                    { 7, 3, "TX", 0 },
                    { 8, 3, "AC", 1 },
                    { 9, 3, "CM", 2 },
                    { 10, 4, "TX", 0 },
                    { 11, 4, "AC", 1 },
                    { 12, 4, "CM", 2 },
                    { 13, 5, "TX", 0 },
                    { 14, 5, "AC", 1 },
                    { 15, 5, "CM", 2 },
                    { 16, 6, "TX", 0 },
                    { 17, 6, "AC", 1 },
                    { 18, 6, "CM", 2 },
                    { 19, 7, "TX", 0 },
                    { 20, 7, "AC", 1 },
                    { 21, 7, "CM", 2 },
                    { 22, 8, "TX", 0 },
                    { 23, 8, "AC", 1 },
                    { 24, 8, "CM", 2 },
                    { 25, 9, "TX", 0 },
                    { 26, 9, "AC", 1 },
                    { 27, 9, "CM", 2 },
                    { 28, 10, "TX", 0 },
                    { 29, 10, "AC", 1 },
                    { 30, 10, "CM", 2 },
                    { 31, 11, "TX", 0 },
                    { 32, 11, "AC", 1 },
                    { 33, 11, "CM", 2 },
                    { 34, 12, "TX", 0 },
                    { 35, 12, "AC", 1 },
                    { 36, 12, "CM", 2 },
                    { 37, 13, "TX", 0 },
                    { 38, 13, "AC", 1 },
                    { 39, 13, "CM", 2 },
                    { 40, 14, "TX", 0 },
                    { 41, 14, "AC", 1 },
                    { 42, 14, "CM", 2 },
                    { 43, 15, "TX", 0 },
                    { 44, 15, "AC", 1 },
                    { 45, 15, "CM", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Removing sample data from DocSetEntity
            migrationBuilder.DeleteData(
                table: "DocSets",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
                    16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
                    29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41,
                    42, 43, 44, 45
                });

            // Removing sample data from DesignObjectEntity
            migrationBuilder.DeleteData(
                table: "DesignObjects",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
                });

            // Removing sample data from Projects
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    1, 2, 3, 4
                });
        }
    }
}
