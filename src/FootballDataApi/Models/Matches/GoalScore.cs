namespace FootballDataApi.Models.Matches;

public sealed record GoalScore
{
    public int Home { get; set; }

    public int Away { get; set; }
}
