namespace FootballDataApi.Models;

public sealed record Scorer
{
    public Person Player { get; set; }

    public Team Team { get; set; }

    public int Goals { get; set; }

    public int Assists { get; set; }

    public int Penalties { get; set; }
}
