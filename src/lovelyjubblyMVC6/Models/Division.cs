using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class Division : IDivision
    {
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}