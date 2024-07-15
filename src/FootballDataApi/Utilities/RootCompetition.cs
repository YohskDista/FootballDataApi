using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

internal sealed record RootCompetition : RootApi
{
    public IReadOnlyCollection<Competition> Competitions { get; set; }
}
