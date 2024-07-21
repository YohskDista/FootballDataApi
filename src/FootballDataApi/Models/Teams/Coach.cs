namespace FootballDataApi.Models.Teams;

public sealed record Coach
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Name { get; set; }

    public string DateOfBirth { get; set; }

    public string Nationality { get; set; }

    public Contract Contract { get; set; }
}


