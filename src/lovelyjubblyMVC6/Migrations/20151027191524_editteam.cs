using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace lovelyjubblyMVC6.Migrations
{
    public partial class editteam : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropColumn(name: "Logo", table: "Teams");
            migration.AddColumn(
                name: "CheerleaderImage",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddColumn(
                name: "CoachImage",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddColumn(
                name: "DivisionId",
                table: "Teams",
                type: "int",
                nullable: true);
            migration.AddColumn(
                name: "HeaderImage",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddColumn(
                name: "LogoImage",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Team_Division_DivisionId",
                table: "Teams",
                column: "DivisionId",
                referencedTable: "Divisions",
                referencedColumn: "DivisionId");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Team_Division_DivisionId", table: "Teams");
            migration.DropColumn(name: "CheerleaderImage", table: "Teams");
            migration.DropColumn(name: "CoachImage", table: "Teams");
            migration.DropColumn(name: "DivisionId", table: "Teams");
            migration.DropColumn(name: "HeaderImage", table: "Teams");
            migration.DropColumn(name: "LogoImage", table: "Teams");
            migration.AddColumn(
                name: "Logo",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
