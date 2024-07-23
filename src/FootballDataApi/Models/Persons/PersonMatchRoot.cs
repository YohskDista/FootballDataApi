using FootballDataApi.Models.Matches;
using System.Collections.Generic;

namespace FootballDataApi.Models.Persons;

internal sealed record PersonMatchRoot
{
    public Filters Filters { get; set; }

    public ResultSet ResultSet { get; set; }

    public Aggregations Aggregations { get; set; }

    public PersonMatch Person { get; set; }

    public IReadOnlyCollection<Match> Matches { get; set; }
}