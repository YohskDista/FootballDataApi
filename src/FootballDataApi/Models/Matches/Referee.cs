namespace FootballDataApi.Models.Matches;

public sealed record Referee : Person
{
    public string Type { get; set; }

    public string? Nationality { get; set; }
}
