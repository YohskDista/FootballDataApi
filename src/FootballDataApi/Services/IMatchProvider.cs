using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Teams;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IMatchProvider
{
    /// <summary>
    /// Get all the matches of the specified competition. You can use multiple 
    /// additional filters but only the competition ID is required.
    /// </summary>
    /// <param name="competitionId">Competition ID which is represented by the competition code.</param>
    /// <param name="season">Season year you are interested on. Can be combined with matchDay.</param>
    /// <param name="matchDay">Match day you are interested on. Can be combined with season</param>
    /// <param name="status">Status of the match</param>
    /// <param name="dateFrom">Start date you are interested on. Can be combined with dateTo.</param>
    /// <param name="dateTo">End date you are interested on. Can be combined with dateFrom.</param>
    /// <param name="stage">Stage of the competition. Only available for cup competitions</param>
    /// <param name="group">Group of the competition. Only available for cup competitions</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="InvalidOperationException">
    ///     You can specify season and matchDay or dateFrom and dateTo, but not both of them.
    /// </exception>
    /// <returns></returns>
    Task<IReadOnlyCollection<Match>> GetAllMatchesOfCompetitionAsync(
        string competitionId, 
        int? season = null,
        int? matchDay = null,
        Status? status = null,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Stage? stage = null,
        Group? group = null,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetAllMatchOfTeamAsync(
        int teamId,
        CancellationToken cancellationToken = default,
        params string[] filters);

    Task<Match> GetMatchByIdAsync(
        int matchId, 
        CancellationToken cancellationToken = default);
}
