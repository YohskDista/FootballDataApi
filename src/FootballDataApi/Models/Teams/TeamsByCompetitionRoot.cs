using System.Collections.Generic;

namespace FootballDataApi.Models.Teams;

internal sealed record TeamsByCompetitionRoot : ApiRootStructure
{
    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<FullDetailedTeam> Teams { get; set;}
}
