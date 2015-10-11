using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;

namespace lovelyjubblyMVC6.Models
{
    public partial class QBRating : IQBRating
    {
        public int QBRatingId { get; set; }

        public string Season { get; set; }

        //foreign key
        public int TeamId { get; set; }
        //navigation properties
        public virtual Team Team { get; set; }

        public double Completion { get; set; }
        public double Gain { get; set; }
        public double Touchdown { get; set; }
        public double Interception { get; set; }
    }
}