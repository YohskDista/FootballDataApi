using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
    public class CompetitionMatches
    {
        public int Count { get; set; }
        public object Filters { get; set; }
        public Season Season { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }

    public class Match
    {
        public int? Id { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public object Minute { get; set; }
        public int? Attendance { get; set; }
        public int? Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public DateTime LastUpdated { get; set; }
        public MatchTeam HomeTeam { get; set; }
        public MatchTeam AwayTeam { get; set; }
        public Score Score { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Substitution> Substitutions { get; set; }
        public IEnumerable<Referee> Referees { get; set; }
    }

    public class Coach
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
    }

    public class Player
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? ShirtNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }
    }

    public class MatchTeam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Coach Coach { get; set; }
        public Player Captain { get; set; }
        public IEnumerable<Player> Lineup { get; set; }
        public IEnumerable<Player> Bench { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Tuple<int?, int?> HalfTime { get; set; }
        public Tuple<int?, int?> FullTime { get; set; }
        public Tuple<int?, int?> ExtraTime { get; set; }
        public Tuple<int?, int?> Penalties { get; set; }
    }

    public class Goal
    {
        public int? Minute { get; set; }
        public Player Scorer { get; set; }
        public IEnumerable<Player> Assist { get; set; }
    }

    public class Booking
    {
        public int? Minute { get; set; }
        public MatchTeam Team { get; set; }
        public Player Player { get; set; }
        public string Card { get; set; }
    }

    public class Substitution
    {
        public int? Minute { get; set; }
        public MatchTeam Team { get; set; }
        public Player PlayerOut { get; set; }
        public Player PlayerIn { get; set; }
    }

    public class Referee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public object Nationality { get; set; }
    }

}
