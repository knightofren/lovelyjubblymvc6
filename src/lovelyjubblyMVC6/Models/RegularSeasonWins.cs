using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class RegularSeasonWins : IRegularSeasonWins
    {
        public int RegularSeasonWinsId { get; set; }
        //foreign key
        public int TeamId { get; set; }
        //navigation properties
        public virtual Team TeamName { get; set; }
        public string Season { get; set; }
        public int Wins { get; set; }
    }
}