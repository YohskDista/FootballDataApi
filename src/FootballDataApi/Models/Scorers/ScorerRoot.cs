using System.Collections.Generic;

namespace FootballDataApi.Models.Scorers;

internal sealed record ScorerRoot : ApiRootStructure
{
    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Scorer> Scorers { get; set; }
}


