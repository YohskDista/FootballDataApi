using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record SeasonStanding
{
    public Area? Area { get; set; }

    public Competition? Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Standing> Standings { get; set; }
}
