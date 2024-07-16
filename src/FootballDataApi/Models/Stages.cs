namespace FootballDataApi.Models;

public enum Venue
{
    Unknown = 0,
    HOME,
    AWAY
}

public enum Lineup
{
    Unknown = 0,
    STARTING,
    BENCH
}

public enum PlayerAction
{
    Unknown = 0,
    GOAL, 
    ASSIST, 
    SUB_IN, 
    SUB_OUT
}

public enum Stages
{
    Unknown = 0,
    FINAL,
    THIRD_PLACE, 
    SEMI_FINALS, 
    QUARTER_FINALS, 
    LAST_16, 
    LAST_32, 
    LAST_64, 
    ROUND_4, 
    ROUND_3, 
    ROUND_2, 
    ROUND_1, 
    GROUP_STAGE, 
    PRELIMINARY_ROUND, 
    QUALIFICATION, 
    QUALIFICATION_ROUND_1, 
    QUALIFICATION_ROUND_2, 
    QUALIFICATION_ROUND_3, 
    PLAYOFF_ROUND_1, 
    PLAYOFF_ROUND_2, 
    PLAYOFFS, 
    REGULAR_SEASON, 
    CLAUSURA, 
    APERTURA, 
    CHAMPIONSHIP_ROUND, 
    RELEGATION_ROUND
}

public enum Group
{
    Unknown = 0,
    GROUP_A, 
    GROUP_B, 
    GROUP_C, 
    GROUP_D, 
    GROUP_E, 
    GROUP_F, 
    GROUP_G, 
    GROUP_H, 
    GROUP_I, 
    GROUP_J, 
    GROUP_K, 
    GROUP_L
}

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
