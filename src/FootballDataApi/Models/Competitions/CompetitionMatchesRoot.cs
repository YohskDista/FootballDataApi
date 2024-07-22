using FootballDataApi.Models.Matches;
using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

internal sealed record CompetitionMatchesRoot : ApiRootStructure
{
    public ResultSet ResultSet { get; set; }

    public AvailableCompetition Competition { get; set; }

    public IReadOnlyCollection<Match> Matches { get; set; }
}
