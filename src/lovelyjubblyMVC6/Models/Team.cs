using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Team : ITeam
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LogoImage { get; set; }
        public string HeaderImage { get; set; }
        public string CoachImage { get; set; }
        public string CheerleaderImage { get; set; }
        //foreign key
        public int DivisionId { get; set; }
        //navigation properties
        public virtual Division Division { get; set; }
    }
}