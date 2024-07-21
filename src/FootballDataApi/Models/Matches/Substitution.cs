using FootballDataApi.Models.Scorers;

namespace FootballDataApi.Models.Matches;

public sealed record Substitution
{
    public int Minute { get; set; }

    public Team Team { get; set; }

    public Player PlayerOut { get; set; }

    public Player PlayerIn { get; set; }
}
