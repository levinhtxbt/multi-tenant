using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTenantSample.Migrations.Master
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DatabaseName = table.Column<string>(nullable: true),
                    DatabaseServer = table.Column<string>(nullable: true),
                    DatabaseUser = table.Column<string>(nullable: true),
                    DatabasePassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
