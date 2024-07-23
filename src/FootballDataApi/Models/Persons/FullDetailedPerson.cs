namespace FootballDataApi.Models.Persons;

public sealed record FullDetailedPerson : PersonMatch
{
    public CurrentTeam CurrentTeam { get; set; }
}
