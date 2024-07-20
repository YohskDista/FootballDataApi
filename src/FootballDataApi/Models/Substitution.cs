using FootballDataApi.Models.Matches;

namespace FootballDataApi.Models
{
    public sealed record Substitution
    {
        public int Minute { get; set; }

        public MatchTeam Team { get; set; }

        public Person PlayerOut { get; set; }

        public Person PlayerIn { get; set; }
    }

}
