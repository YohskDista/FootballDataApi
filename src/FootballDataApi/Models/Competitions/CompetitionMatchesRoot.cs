using FootballDataApi.Models.Matches;
using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

public sealed record CompetitionMatchesRoot
{
    public Filters Filters { get; set; }

    public ResultSet ResultSet { get; set; }

    public Competition Competition { get; set; }

    public IReadOnlyCollection<Match> Matches { get; set; }
}
