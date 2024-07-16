namespace FootballDataApi.Models;

public sealed record Contract
{
    public string Start { get; set; }

    public string Until { get; set; }
}