namespace FootballDataApi.Models;

public sealed record Odds
{
    public double HomeWin { get; set; }

    public double Draw { get; set; }

    public double AwayWin { get; set; }
}
