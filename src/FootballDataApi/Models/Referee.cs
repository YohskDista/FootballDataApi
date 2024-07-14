namespace FootballDataApi.Models;

public sealed record Referee
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public object Nationality { get; set; }
}
