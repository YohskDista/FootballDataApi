using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record SeasonStanding
{
    public Season Season { get; set; }

    public IEnumerable<Standing> Standings { get; set; }
}
