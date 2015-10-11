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
        public string Logo { get; set; }
    }
}