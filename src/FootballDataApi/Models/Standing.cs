using System.Collections.Generic;

namespace FootballDataApi.Models;

public sealed record Standing
{
    public string Stage { get; set; }

    public string Type { get; set; }

    public object Group { get; set; }

    public IReadOnlyCollection<Ranking> Table { get; set; }
}
