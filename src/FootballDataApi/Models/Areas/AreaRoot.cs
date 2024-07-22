using System.Collections.Generic;

namespace FootballDataApi.Models.Areas;

internal sealed record AreaRoot : ApiRootStructure
{
    public IReadOnlyCollection<DetailedArea> Areas { get; set; }
}
