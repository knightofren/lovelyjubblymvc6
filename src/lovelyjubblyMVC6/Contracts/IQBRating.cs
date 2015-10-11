using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.Contracts
{
    public interface IQBRating
    {
        double Completion { get; set; }
        double Gain { get; set; }
        double Interception { get; set; }
        int QBRatingId { get; set; }
        string Season { get; set; }
        Team Team { get; set; }
        int TeamId { get; set; }
        double Touchdown { get; set; }
    }
}