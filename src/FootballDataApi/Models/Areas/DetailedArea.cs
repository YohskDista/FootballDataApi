namespace FootballDataApi.Models;

public record DetailedArea : Area
{
    public int? ParentAreaId { get; set; }

    public string? ParentArea { get; set; }
}