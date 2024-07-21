using System;
using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

public sealed record Competition
{
    public Area Area { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Type { get; set; }

    public string Emblem { get; set; }

    public CurrentSeason CurrentSeason { get; set; }

    public IReadOnlyList<Season> Seasons { get; set; }

    public DateTime LastUpdated { get; set; }
}

