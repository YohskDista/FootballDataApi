namespace FootballDataApi.Models.Competitions;

public sealed record Area
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Flag { get; set; }
}

