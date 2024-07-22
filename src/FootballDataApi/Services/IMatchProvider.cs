using FootballDataApi.Models.Matches;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IMatchProvider
{
    Task<IReadOnlyCollection<Match>> GetAllMatchesAsync(CancellationToken cancellationToken = default, params string[] filters);

    Task<IReadOnlyCollection<Match>> GetAllMatchOfCompetitionAsync(
        int competitionId,
        CancellationToken cancellationToken = default,
        params string[] filters);

    Task<IReadOnlyCollection<Match>> GetAllMatchOfTeamAsync(
        int teamId,
        CancellationToken cancellationToken = default,
        params string[] filters);

    Task<Match> GetMatchByIdAsync(
        int matchId, 
        CancellationToken cancellationToken = default);
}
