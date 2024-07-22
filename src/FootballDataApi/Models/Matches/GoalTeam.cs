namespace FootballDataApi.Models.Matches;

public sealed record GoalTeam
{
    public int Id { get; set; }

    public string Team { get; set; }
}
