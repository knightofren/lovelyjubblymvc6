using lovelyjubblyMVC6.Models;

namespace lovelyjubblyMVC6.Contracts
{
    public interface ITeam
    {
        int TeamId { get; set; }
        string TeamName { get; set; }
        string LogoImage { get; set; }
        string HeaderImage { get; set; }
        string CoachImage { get; set; }
        string CheerleaderImage { get; set; }
        int DivisionId { get; set; }
        Division Division { get; set; }
    }
}