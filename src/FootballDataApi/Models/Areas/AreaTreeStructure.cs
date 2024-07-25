using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record AreaTreeStructure
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Code { get; set; }

    public string? Flag { get; set; }

    public int? ParentAreaId { get; set; }

    public string? ParentArea { get; set; }

    public IReadOnlyCollection<DetailedArea>? ChildAreas { get; set; }
}
