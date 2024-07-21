namespace FootballDataApi.Models.Standings;

public sealed record Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string type { get; set; }
    public string emblem { get; set; }
}


