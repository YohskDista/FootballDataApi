using System.Collections.Generic;

namespace FootballDataApi.Models.Standings;

public sealed record StandingsRoot
{
    public Filters Filters { get; set; }

    public Area Area { get; set; }

    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Standing> Standings { get; set; }
}


