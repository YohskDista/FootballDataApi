using System.Collections.Generic;

namespace FootballDataApi.Models.Scorers;

public class Root
{
    public int Count { get; set; }

    public Filters Filters { get; set; }

    public Competition Competition { get; set; }

    public Season Season { get; set; }

    public IReadOnlyCollection<Scorer> Scorers { get; set; }
}


