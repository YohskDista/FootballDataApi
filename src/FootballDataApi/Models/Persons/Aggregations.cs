namespace FootballDataApi.Models.Persons;

public sealed record Aggregations
{
    public int MatchesOnPitch { get; set; }

    public int StartingXI { get; set; }

    public int MinutesPlayed { get; set; }

    public int Goals { get; set; }

    public int OwnGoals { get; set; }

    public int Assists { get; set; }

    public int Penalties { get; set; }

    public int SubbedOut { get; set; }

    public int SubbedIn { get; set; }

    public int YellowCards { get; set; }

    public int YellowRedCards { get; set; }

    public int RedCards { get; set; }
}


