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
    Task<Match> GetMatchByIdAsync(
        int matchId, 
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetMatchesAsync(
        IEnumerable<int>? ids = null,
        DateTime? date = null,
        Status? status = null,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Match>> GetMatchesBetweenAsync(
        DateTime dateFrom,
        DateTime dateTo,
        IEnumerable<int>? ids = null,
        Status? status = null,
        CancellationToken cancellationToken = default);
}
