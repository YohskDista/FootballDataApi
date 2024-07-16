namespace FootballDataApi.Models;

public class Score
{
    public string Winner { get; set; }

    public string Duration { get; set; }

    public GoalScore? HalfTime { get; set; }

    public GoalScore? FullTime { get; set; }

    public GoalScore? ExtraTime { get; set; }

    public GoalScore? Penalties { get; set; }
}
