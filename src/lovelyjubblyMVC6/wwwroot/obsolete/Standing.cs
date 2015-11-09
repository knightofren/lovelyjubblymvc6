using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Standing : IStanding
    {
        public int StandingId { get; set; }
        public string Season { get; set; }

        //foreign key
        public int DivisionId { get; set; }
        //navigation properties
        public virtual Division Division { get; set; }

        //foreign key
        public int TeamId { get; set; }
        //navigation properties
        public virtual Team Team { get; set; }

        //foreign key
        public int CoachId { get; set; }
        //navigation properties
        public virtual Coach Coach { get; set; }

        public int Won { get; set; }
        public int Lost { get; set; }
        public int Tied { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
    }
}