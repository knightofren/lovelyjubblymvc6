using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.Contracts
{
    public interface IRegularSeasonWins
    {
        int RegularSeasonWinsId { get; set; }
        int TeamId { get; set; }
        Team TeamName { get; set; }
        string Season { get; set; }
        int Wins { get; set; }
    }
}