using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Area
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string CountryCode { get; set; }

    public string Flag {  get; set; }

    public int? ParentAreaId { get; set; }

    public string? ParentArea { get; set; }

    public IReadOnlyCollection<Area>? ChildAreas { get; set; }
}
