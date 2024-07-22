using System.Collections.Generic;

namespace FootballDataApi.Models.Teams;

internal sealed record TeamsByCompetitionRoot
{
    public int Count { get; set; }

    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<FullDetailedTeam> Teams { get; set;}
}
