namespace FootballDataApi.Models;

public sealed record Coach
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string CountryOfBirth { get; set; }

    public string Nationality { get; set; }
}
