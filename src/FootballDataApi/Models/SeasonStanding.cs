using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record SeasonStanding
{
    public Season Season { get; set; }

    public IReadOnlyCollection<Standing> Standings { get; set; }
}
