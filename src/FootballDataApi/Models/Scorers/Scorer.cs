namespace FootballDataApi.Models.Scorers;

public class Scorer
{
    public Player Player { get; set; }

    public ScorerTeam Team { get; set; }

    public int Goals { get; set; }

    public int Assists { get; set; }

    public int Penalties { get; set; }
}
