namespace FootballDataApi.Models.Matches;
public sealed record Coach
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Nationality { get; set; }
}
