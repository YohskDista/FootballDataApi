namespace FootballDataApi.Models;

public enum Status
{
    Unknown = 0,
    SCHEDULED,
    TIMED,
    IN_PLAY,
    PAUSED,
    FINISHED,
    SUSPENDED,
    POSTPONED,
    CANCELLED,
    AWARDED
}
