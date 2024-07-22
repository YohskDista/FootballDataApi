using System.Collections.Generic;

namespace FootballDataApi.Models.Competitions;

internal sealed record CompetitionRoot : ApiRootStructure
{
    public IReadOnlyCollection<AvailableCompetition> Competitions { get; set; }
}
