using System.Collections.Generic;

namespace FootballDataApi.Models.Standings;

public sealed record Standing
{
    public string Stage { get; set; }
    public string Type { get; set; }
    public object Group { get; set; }
    public IReadOnlyCollection<Table> Table { get; set; }
}


