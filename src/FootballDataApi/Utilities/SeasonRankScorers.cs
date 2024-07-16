using System.Collections.Generic;
using FootballDataApi.Models;

namespace FootballDataApi.Utilities;

public sealed record SeasonRankScorers : RootApi
{
    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Scorer> Scorers { get; set; }
}
