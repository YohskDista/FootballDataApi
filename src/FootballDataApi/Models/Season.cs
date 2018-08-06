using System;

namespace FootballDataApi.Models
{
    public class Season
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public string[] AvailableStages { get; set; }
    }
}
