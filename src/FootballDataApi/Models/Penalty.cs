namespace FootballDataApi.Models;

public sealed record Penalty
{
    public Person Player { get; set; }

    public Team Team { get; set; }

    public bool Scored { get; set; }
}
