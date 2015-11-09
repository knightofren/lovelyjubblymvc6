using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Tournament : ITournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string Season { get; set; }
    }
}