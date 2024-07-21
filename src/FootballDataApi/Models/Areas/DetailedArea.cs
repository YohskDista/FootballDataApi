using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record DetailedArea : Area
{
    public int? ParentAreaId { get; set; }

    public string? ParentArea { get; set; }

    public IReadOnlyCollection<DetailedArea>? ChildAreas { get; set; }
}
