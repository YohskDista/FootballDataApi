namespace FootballDataApi.Models;

public sealed record Referee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public string? Nationality { get; set; }
}
