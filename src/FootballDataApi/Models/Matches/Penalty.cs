using FootballDataApi.Models.Scorers;

namespace FootballDataApi.Models.Matches;

public sealed record Penalty
{
    public Player Player { get; set; }
    public Team Team { get; set; }
    public bool Scored { get; set; }
}
