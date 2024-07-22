namespace FootballDataApi.Models.Competitions;

public sealed record Filters
{
    public string Season { get; set; }

    public string Matchday { get; set; }
}
