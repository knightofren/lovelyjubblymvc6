using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Coach : ICoach
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
    }
}