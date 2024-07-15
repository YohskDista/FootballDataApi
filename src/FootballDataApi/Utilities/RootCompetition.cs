using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

internal sealed record RootCompetition : RootApi
{
    public IEnumerable<Competition> Competitions { get; set; }
}
