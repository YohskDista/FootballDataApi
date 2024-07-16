namespace FootballDataApi.Models;

public sealed record Booking
{
    public int? Minute { get; set; }

    public MatchTeam Team { get; set; }

    public Person Player { get; set; }

    public string Card { get; set; }
}
