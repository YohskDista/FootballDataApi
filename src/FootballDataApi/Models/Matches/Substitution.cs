using FootballDataApi.Models.Scorers;

namespace FootballDataApi.Models.Matches;

public sealed record Substitution
{
    public int Minute { get; set; }

    public Team Team { get; set; }

    public Person PlayerOut { get; set; }

    public Person PlayerIn { get; set; }
}
