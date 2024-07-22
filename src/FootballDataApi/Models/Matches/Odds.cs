namespace FootballDataApi.Models.Matches;

public sealed record Odds
{
    public double HomeWin { get; set; }

    public double Draw { get; set; }

    public double AwayWin { get; set; }
}
