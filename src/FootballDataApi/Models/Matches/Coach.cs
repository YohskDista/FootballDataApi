namespace FootballDataApi.Models.Matches;

public sealed record Coach : Person
{
    public string Nationality { get; set; }
}
