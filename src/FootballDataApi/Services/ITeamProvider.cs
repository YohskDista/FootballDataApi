using FootballDataApi.Models;
using FootballDataApi.Models.Matches;
using FootballDataApi.Models.Teams;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ITeamProvider
{
    Task<IReadOnlyCollection<FullDetailedTeam>> GetTeamsByCompetitionAsync(
        string competitionId,
        CancellationToken cancellationToken = default,
        params string[] filters);

    Task<FullDetailedTeam> GetTeamByIdAsync(
        int teamId, 
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetMatchesForTeamAsync(
        int teamId,
        int season,
        Status? status = null,
        Venue? venue = null,
        int limit = 500,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetMatchesForTeamBetweenAsync(
        int teamId,
        DateTime dateFrom, 
        DateTime dateTo,
        Status? status = null,
        Venue? venue = null,
        int limit = 500,
        CancellationToken cancellationToken = default);
}
