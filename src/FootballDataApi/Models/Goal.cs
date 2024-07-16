using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Goal
{
    public int Minute { get; set; }

    public int? InjuryTime { get; set; }

    public string Type { get; set; }

    public Person Scorer { get; set; }

    public Person? Assist { get; set; }

    public GoalScore Score { get; set; }
}
