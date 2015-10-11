using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Fixture : IFixture
    {
        public int FixtureId { get; set; }

        public string Season { get; set; }
        public byte Week { get; set; }

        //foreign key
        public int AwayTeamId { get; set; }
        //navigation properties
        public virtual Team AwayTeam { get; set; }

        //foreign key
        public int HomeTeamId { get; set; }
        //navigation properties
        public virtual Team HomeTeam { get; set; }

        public byte? AwayTeamScore { get; set; }
        public byte? HomeTeamScore { get; set; }
    }
}