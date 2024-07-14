using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

public sealed record RootMatch : RootApi
{
    public IEnumerable<Match> Matches { get; set; }
}
