using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Utilities;

public sealed record RootCompetition : RootApi
{
    public IEnumerable<Competition> Competitions { get; set; }
}
