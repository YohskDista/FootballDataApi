using FootballDataApi.Models.Teams;
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
}
