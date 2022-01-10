using Microsoft.EntityFrameworkCore.Migrations;

namespace DBServer.Migrations
{
    public partial class MonstersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "AtackModifier",
                table: "MonstersData");

            migrationBuilder.RenameColumn(
                name: "Weapon",
                table: "MonstersData",
                newName: "DamageModifier");

            migrationBuilder.RenameColumn(
                name: "DamagePerRound",
                table: "MonstersData",
                newName: "AttackPerRound");

            migrationBuilder.RenameColumn(
                name: "AtackPerRound",
                table: "MonstersData",
                newName: "AttackModifier");

            migrationBuilder.AlterColumn<string>(
                name: "Damage",
                table: "MonstersData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AC", "AttackModifier", "AttackPerRound", "Damage", "DamageModifier", "HitPoints", "MinACtoAlwaysHit", "MonsterName" },
                values: new object[] { 18, 5, 2, "2d6", 3, 52, 6, "Knight" });

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AC", "AttackModifier", "AttackPerRound", "Damage", "MinACtoAlwaysHit" },
                values: new object[] { 10, 2, 1, "2k6", 3 });

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AC", "AttackModifier", "AttackPerRound", "Damage", "HitPoints", "MinACtoAlwaysHit", "MonsterName" },
                values: new object[] { 12, 1, 1, "1d4", 3, 2, "Baboon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DamageModifier",
                table: "MonstersData",
                newName: "Weapon");

            migrationBuilder.RenameColumn(
                name: "AttackPerRound",
                table: "MonstersData",
                newName: "DamagePerRound");

            migrationBuilder.RenameColumn(
                name: "AttackModifier",
                table: "MonstersData",
                newName: "AtackPerRound");

            migrationBuilder.AlterColumn<int>(
                name: "Damage",
                table: "MonstersData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AtackModifier",
                table: "MonstersData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AC", "AtackPerRound", "Damage", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "MonsterName", "Weapon" },
                values: new object[] { 0, 0, 0, 0, 59, 0, "Griffon", 0 });

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AC", "AtackPerRound", "Damage", "DamagePerRound", "MinACtoAlwaysHit" },
                values: new object[] { 0, 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "MonstersData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AC", "AtackPerRound", "Damage", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "MonsterName" },
                values: new object[] { 0, 0, 0, 0, 40, 0, "Mage" });

            migrationBuilder.InsertData(
                table: "MonstersData",
                columns: new[] { "Id", "AC", "AtackModifier", "AtackPerRound", "Damage", "DamagePerRound", "HitPoints", "MinACtoAlwaysHit", "MonsterName", "Weapon" },
                values: new object[] { 4, 21, 5, 0, 0, 0, 187, 0, "Fire giant dreadnought", 0 });
        }
    }
}
