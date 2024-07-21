namespace FootballDataApi.Models.Matches;
public sealed record Player : Person
{
    public string Position { get; set; }

    public int ShirtNumber { get; set; }
}
