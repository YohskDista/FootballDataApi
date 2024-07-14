namespace FootballDataApi.Models
{
    public sealed record Substitution
    {
        public int? Minute { get; set; }

        public MatchTeam Team { get; set; }

        public Player PlayerOut { get; set; }

        public Player PlayerIn { get; set; }
    }

}
