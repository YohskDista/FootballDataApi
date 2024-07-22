using System.Collections.Generic;

namespace FootballDataApi.Models.Standings;

public sealed record Standing
{
    public Stages Stage { get; set; }

    public string Type { get; set; }

    public Group? Group { get; set; }

    public IReadOnlyCollection<Table> Table { get; set; }
}


