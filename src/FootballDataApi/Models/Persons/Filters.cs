namespace FootballDataApi.Models.Persons;

public sealed record Filters
{
    public int Limit { get; set; }

    public int Offset { get; set; }

    public string Competitions { get; set; }

    public string Permission { get; set; }
}


