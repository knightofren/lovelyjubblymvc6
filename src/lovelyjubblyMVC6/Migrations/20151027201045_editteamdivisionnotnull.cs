using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace lovelyjubblyMVC6.Migrations
{
    public partial class editteamdivisionnotnull : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.AlterColumn(
                name: "DivisionId",
                table: "Teams",
                type: "int",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.AddColumn(
                name: "DivisionId",
                table: "Teams",
                type: "int",
                nullable: true);
        }
    }
}
