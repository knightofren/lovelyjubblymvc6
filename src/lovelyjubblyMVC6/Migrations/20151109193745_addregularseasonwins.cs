using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace lovelyjubblyMVC6.Migrations
{
    public partial class addregularseasonwins : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "RegularSeasonWins",
                columns: table => new
                {
                    RegularSeasonWinsId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Season = table.Column(type: "nchar(4)", nullable: false),
                    TeamId = table.Column(type: "int", nullable: false),
                    Wins = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSeasonWins", x => x.RegularSeasonWinsId);
                    table.ForeignKey(
                        name: "FK_RegularSeasonWins_Team_TeamId",
                        columns: x => x.TeamId,
                        referencedTable: "Teams",
                        referencedColumn: "TeamId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("RegularSeasonWins");
        }
    }
}
