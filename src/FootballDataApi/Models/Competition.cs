using System;
using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Competition
{
    public int Id { get; set; }

    public Area Area { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public string Type { get; set; }

    public string Emblem { get; set; }

    public Season CurrentSeason { get; set; }

    public IReadOnlyCollection<Season> Seasons { get; set; }

    public int NumberOfAvailableSeasons { get; set; }

    public DateTime LastUpdated { get; set; }
}
