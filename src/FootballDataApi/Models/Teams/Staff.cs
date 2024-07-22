namespace FootballDataApi.Models.Teams;

public sealed record Staff : Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public Contract Contract { get; set; }
}


