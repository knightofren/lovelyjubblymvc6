using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.Contracts
{
    public interface IStanding
    {
        Coach Coach { get; set; }
        int CoachId { get; set; }
        Division Division { get; set; }
        int DivisionId { get; set; }
        int Lost { get; set; }
        int PointsAgainst { get; set; }
        int PointsFor { get; set; }
        string Season { get; set; }
        int StandingId { get; set; }
        Team Team { get; set; }
        int TeamId { get; set; }
        int Tied { get; set; }
        int Won { get; set; }
    }
}