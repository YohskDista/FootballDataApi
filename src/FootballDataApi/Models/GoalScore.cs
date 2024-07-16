namespace FootballDataApi.Models;

public sealed record GoalScore
{
    public int HomeTeam { get; set; }

    public int AwayTeam { get; set; }
}
