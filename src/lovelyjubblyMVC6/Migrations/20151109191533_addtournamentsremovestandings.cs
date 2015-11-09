using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace lovelyjubblyMVC6.Migrations
{
    public partial class addtournamentsremovestandings : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Season = table.Column(type: "nchar(4)", nullable: false),
                    TournamentName = table.Column(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.TournamentId);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Tournaments");
        }
    }
}
