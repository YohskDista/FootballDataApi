using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

internal sealed record RootMatch : RootApi
{
    public IReadOnlyCollection<Match> Matches { get; set; }
}
