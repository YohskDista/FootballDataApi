using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Domain
{
    public class Match
    {
        public int Id { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public object Minute { get; set; }
        public int Attendance { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public DateTime LastUpdated { get; set; }
        public MatchTeam HomeTeam { get; set; }
        public MatchTeam AwayTeam { get; set; }
        public Score Score { get; set; }
        public Goal[] Goals { get; set; }
        public Booking[] Bookings { get; set; }
        public Substitution[] Substitutions { get; set; }
        public Referee[] Referees { get; set; }
    }

    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }
    }

    public class MatchTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coach Coach { get; set; }
        public Player Captain { get; set; }
        public Player[] Lineup { get; set; }
        public Player[] Bench { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public Halftime HalfTime { get; set; }
        public Fulltime FullTime { get; set; }
        public Extratime ExtraTime { get; set; }
        public Penalties Penalties { get; set; }
    }

    public class Halftime
    {
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
    }

    public class Fulltime
    {
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
    }

    public class Extratime
    {
        public object HomeTeam { get; set; }
        public object AwayTeam { get; set; }
    }

    public class Penalties
    {
        public object HomeTeam { get; set; }
        public object AwayTeam { get; set; }
    }

    public class Goal
    {
        public int minute { get; set; }
        public Player scorer { get; set; }
        public Player[] assist { get; set; }
    }

    public class Booking
    {
        public int Minute { get; set; }
        public MatchTeam Team { get; set; }
        public Player Player { get; set; }
        public string Card { get; set; }
    }

    public class Substitution
    {
        public int Minute { get; set; }
        public MatchTeam Team { get; set; }
        public Player PlayerOut { get; set; }
        public Player PlayerIn { get; set; }
    }

    public class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Nationality { get; set; }
    }

}
