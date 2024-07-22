using System.Collections.Generic;

namespace FootballDataApi.Models.Matches;

internal sealed record MatchRoot : ApiRootStructure
{
    public IReadOnlyCollection<Match> Matches { get; set; }
}
