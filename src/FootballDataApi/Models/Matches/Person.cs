namespace FootballDataApi.Models.Matches;
public sealed record Person
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Position { get; set; }

    public int ShirtNumber { get; set; }
}
