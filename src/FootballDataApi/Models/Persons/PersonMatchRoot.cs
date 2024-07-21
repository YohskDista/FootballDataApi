namespace FootballDataApi.Models.Persons;

public sealed record PersonMatchRoot
{
    public Filters Filters { get; set; }

    public ResultSet ResultSet { get; set; }

    public Aggregations Aggregations { get; set; }

    public PersonMatch Person { get; set; }
}


