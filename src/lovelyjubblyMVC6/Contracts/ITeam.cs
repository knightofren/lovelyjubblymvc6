namespace lovelyjubblyMVC6.Contracts
{
    public interface ITeam
    {
        string Logo { get; set; }
        int TeamId { get; set; }
        string TeamName { get; set; }
    }
}