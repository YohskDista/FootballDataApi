using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

public sealed record DetailedCompetition : Competition
{
    public Area Area { get; set; }

    public Season CurrentSeason { get; set; }

    public IReadOnlyList<Season> Seasons { get; set; }

    public DateTime LastUpdated { get; set; }
}

