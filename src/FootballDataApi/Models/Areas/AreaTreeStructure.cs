using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record AreaTreeStructure : DetailedArea
{
    public IReadOnlyCollection<DetailedArea>? ChildAreas { get; set; }
}
