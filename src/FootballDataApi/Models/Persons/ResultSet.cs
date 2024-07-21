namespace FootballDataApi.Models.Persons;

public sealed record ResultSet
{
    public int Count { get; set; }

    public string Competitions { get; set; }

    public string First { get; set; }

    public string Last { get; set; }
}


