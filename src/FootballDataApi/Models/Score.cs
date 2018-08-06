using System;

namespace FootballDataApi.Models
{
    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Tuple<int?, int?> HalfTime { get; set; }
        public Tuple<int?, int?> FullTime { get; set; }
        public Tuple<int?, int?> ExtraTime { get; set; }
        public Tuple<int?, int?> Penalties { get; set; }
    }

}
