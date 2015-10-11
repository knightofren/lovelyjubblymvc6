using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace lovelyjubblyMVC6.Migrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    CoachName = table.Column(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachId);
                });
            migration.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    DivisionName = table.Column(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                });
            migration.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Logo = table.Column(type: "nvarchar(max)", nullable: true),
                    TeamName = table.Column(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });
            migration.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    FixtureId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    AwayTeamId = table.Column(type: "int", nullable: false),
                    AwayTeamScore = table.Column(type: "tinyint", nullable: true),
                    HomeTeamId = table.Column(type: "int", nullable: false),
                    HomeTeamScore = table.Column(type: "tinyint", nullable: true),
                    Season = table.Column(type: "nvarchar(max)", nullable: false),
                    Week = table.Column(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.FixtureId);
                    table.ForeignKey(
                        name: "FK_Fixture_Team_AwayTeamId",
                        columns: x => x.AwayTeamId,
                        referencedTable: "Teams",
                        referencedColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Fixture_Team_HomeTeamId",
                        columns: x => x.HomeTeamId,
                        referencedTable: "Teams",
                        referencedColumn: "TeamId");
                });
            migration.CreateTable(
                name: "QBRatings",
                columns: table => new
                {
                    QBRatingId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Completion = table.Column(type: "float", nullable: false),
                    Gain = table.Column(type: "float", nullable: false),
                    Interception = table.Column(type: "float", nullable: false),
                    Season = table.Column(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column(type: "int", nullable: false),
                    Touchdown = table.Column(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QBRating", x => x.QBRatingId);
                    table.ForeignKey(
                        name: "FK_QBRating_Team_TeamId",
                        columns: x => x.TeamId,
                        referencedTable: "Teams",
                        referencedColumn: "TeamId");
                });
            migration.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    StandingId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    CoachId = table.Column(type: "int", nullable: false),
                    DivisionId = table.Column(type: "int", nullable: false),
                    Lost = table.Column(type: "int", nullable: false),
                    PointsAgainst = table.Column(type: "int", nullable: false),
                    PointsFor = table.Column(type: "int", nullable: false),
                    Season = table.Column(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column(type: "int", nullable: false),
                    Tied = table.Column(type: "int", nullable: false),
                    Won = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standing", x => x.StandingId);
                    table.ForeignKey(
                        name: "FK_Standing_Coach_CoachId",
                        columns: x => x.CoachId,
                        referencedTable: "Coaches",
                        referencedColumn: "CoachId");
                    table.ForeignKey(
                        name: "FK_Standing_Division_DivisionId",
                        columns: x => x.DivisionId,
                        referencedTable: "Divisions",
                        referencedColumn: "DivisionId");
                    table.ForeignKey(
                        name: "FK_Standing_Team_TeamId",
                        columns: x => x.TeamId,
                        referencedTable: "Teams",
                        referencedColumn: "TeamId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Coaches");
            migration.DropTable("Divisions");
            migration.DropTable("Fixtures");
            migration.DropTable("QBRatings");
            migration.DropTable("Standings");
            migration.DropTable("Teams");
        }
    }
}
