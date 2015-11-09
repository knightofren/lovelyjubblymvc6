namespace lovelyjubblyMVC6.Contracts
{
    public interface ITournament
    {
        int TournamentId { get; set; }
        string TournamentName { get; set; }
        string Season { get; set; }
    }
}