using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.Contracts
{
    public interface IFixture
    {
        Team AwayTeam { get; set; }
        int AwayTeamId { get; set; }
        byte? AwayTeamScore { get; set; }
        int FixtureId { get; set; }
        Team HomeTeam { get; set; }
        int HomeTeamId { get; set; }
        byte? HomeTeamScore { get; set; }
        string Season { get; set; }
        byte Week { get; set; }
    }
}