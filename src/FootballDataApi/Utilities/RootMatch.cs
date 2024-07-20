using FootballDataApi.Models.Matches;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

public sealed record RootMatch : RootApi
{
    public IReadOnlyCollection<Match> Matches { get; set; }
}
