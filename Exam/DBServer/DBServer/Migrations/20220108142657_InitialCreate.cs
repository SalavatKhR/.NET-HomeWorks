using Microsoft.EntityFrameworkCore.Migrations;

namespace DBServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonstersData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    AtackModifier = table.Column<int>(type: "int", nullable: false),
                    AtackPerRound = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Weapon = table.Column<int>(type: "int", nullable: false),
                    AC = table.Column<int>(type: "int", nullable: false),
                    MinACtoAlwaysHit = table.Column<int>(type: "int", nullable: false),
                    DamagePerRound = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonstersData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MonstersData",
                columns: new[] { "Id", "AC", "AtackModifier", "AtackPerRound", "Damage", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "MonsterName", "Weapon" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, 0, 59, 0, "Griffon", 0 },
                    { 2, 0, 0, 0, 0, 0, 24, 0, "Swarm of rats", 0 },
                    { 3, 0, 0, 0, 0, 0, 40, 0, "Mage", 0 },
                    { 4, 21, 5, 0, 0, 0, 187, 0, "Fire giant dreadnought", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonstersData");
        }
    }
}
