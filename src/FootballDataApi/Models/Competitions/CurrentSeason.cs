using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

public sealed record CurrentSeason
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CurrentMatchday { get; set; }

    public Winner Winner { get; set; }

    public IReadOnlyList<string> Stages { get; set; }
}

