using FootballDataApi.Models.Scorers;

namespace FootballDataApi.Models.Matches;

public sealed record Booking
{
    public int Minute { get; set; }
    public Team Team { get; set; }
    public Player Player { get; set; }
    public string Card { get; set; }
}
