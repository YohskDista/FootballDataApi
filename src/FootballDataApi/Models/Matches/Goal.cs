namespace FootballDataApi.Models.Matches;

public sealed record Goal
{
    public int Minute { get; set; }

    public int? InjuryTime { get; set; }

    public string Type { get; set; }

    public GoalTeam Team { get; set; }

    public GoalScorer Scorer { get; set; }

    public GoalScorer? Assist { get; set; }

    public GoalScore Score { get; set; }
}
