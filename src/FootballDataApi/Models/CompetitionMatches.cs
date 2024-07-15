using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record CompetitionMatches
{
    public int Count { get; set; }

    public object Filters { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Match> Matches { get; set; }
}
