using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using lovelyjubblyMVC6.DataAccess;

namespace lovelyjubblyMVC6.Migrations
{
    [ContextType(typeof(lovelyjubblyMVC6WebApiContext))]
    partial class editteamdivisionnotnull
    {
        public override string Id
        {
            get { return "20151027201045_editteamdivisionnotnull"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("lovelyjubblyMVC6.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<string>("CoachName")
                        .Required()
                        .Annotation("MaxLength", 50);
                    
                    b.Key("CoachId");
                    
                    b.Annotation("Relational:TableName", "Coaches");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Division", b =>
                {
                    b.Property<int?>("DivisionId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<string>("DivisionName")
                        .Required()
                        .Annotation("MaxLength", 15);
                    
                    b.Key("DivisionId");
                    
                    b.Annotation("Relational:TableName", "Divisions");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<int>("AwayTeamId");
                    
                    b.Property<byte?>("AwayTeamScore");
                    
                    b.Property<int>("HomeTeamId");
                    
                    b.Property<byte?>("HomeTeamScore");
                    
                    b.Property<string>("Season")
                        .Required()
                        .Annotation("MaxLength", 4);
                    
                    b.Property<byte>("Week");
                    
                    b.Key("FixtureId");
                    
                    b.Annotation("Relational:TableName", "Fixtures");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.QBRating", b =>
                {
                    b.Property<int>("QBRatingId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<double>("Completion");
                    
                    b.Property<double>("Gain");
                    
                    b.Property<double>("Interception");
                    
                    b.Property<string>("Season")
                        .Required()
                        .Annotation("MaxLength", 4);
                    
                    b.Property<int>("TeamId");
                    
                    b.Property<double>("Touchdown");
                    
                    b.Key("QBRatingId");
                    
                    b.Annotation("Relational:TableName", "QBRatings");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Standing", b =>
                {
                    b.Property<int>("StandingId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<int>("CoachId");
                    
                    b.Property<int>("DivisionId");
                    
                    b.Property<int>("Lost");
                    
                    b.Property<int>("PointsAgainst");
                    
                    b.Property<int>("PointsFor");
                    
                    b.Property<string>("Season")
                        .Required()
                        .Annotation("MaxLength", 4);
                    
                    b.Property<int>("TeamId");
                    
                    b.Property<int>("Tied");
                    
                    b.Property<int>("Won");
                    
                    b.Key("StandingId");
                    
                    b.Annotation("Relational:TableName", "Standings");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity)
                        .Annotation("SqlServer:ValueGeneration", "Identity");
                    
                    b.Property<string>("CheerleaderImage");
                    
                    b.Property<string>("CoachImage");
                    
                    b.Property<int>("DivisionId");
                    
                    b.Property<string>("HeaderImage");
                    
                    b.Property<string>("LogoImage");
                    
                    b.Property<string>("TeamName")
                        .Required()
                        .Annotation("MaxLength", 75);
                    
                    b.Key("TeamId");
                    
                    b.Annotation("Relational:TableName", "Teams");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Fixture", b =>
                {
                    b.Reference("lovelyjubblyMVC6.Models.Team")
                        .InverseCollection()
                        .ForeignKey("AwayTeamId");
                    
                    b.Reference("lovelyjubblyMVC6.Models.Team")
                        .InverseCollection()
                        .ForeignKey("HomeTeamId");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.QBRating", b =>
                {
                    b.Reference("lovelyjubblyMVC6.Models.Team")
                        .InverseCollection()
                        .ForeignKey("TeamId");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Standing", b =>
                {
                    b.Reference("lovelyjubblyMVC6.Models.Coach")
                        .InverseCollection()
                        .ForeignKey("CoachId");
                    
                    b.Reference("lovelyjubblyMVC6.Models.Division")
                        .InverseCollection()
                        .ForeignKey("DivisionId");
                    
                    b.Reference("lovelyjubblyMVC6.Models.Team")
                        .InverseCollection()
                        .ForeignKey("TeamId");
                });
            
            builder.Entity("lovelyjubblyMVC6.Models.Team", b =>
                {
                    b.Reference("lovelyjubblyMVC6.Models.Division")
                        .InverseCollection()
                        .ForeignKey("DivisionId");
                });
        }
    }
}
