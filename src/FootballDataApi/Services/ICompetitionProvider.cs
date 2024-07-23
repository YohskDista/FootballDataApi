using FootballDataApi.Models.Competitions;
using FootballDataApi.Models.Scorers;
using FootballDataApi.Models.Teams;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ICompetitionProvider
{
    Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionsByAreaAsync(
        IEnumerable<int> areaIds, 
        CancellationToken cancellationToken = default);

    Task<DetailedCompetition> GetCompetitionAsync(
        string competitionId, 
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Scorer>> GetScorersForCompetitionAsync(
        string competitionId,
        int? season = null,
        int? matchDay = null,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<FullDetailedTeam>> GetCompetitionTeamsAsync(
        string competitionId, 
        int? season = null, 
        CancellationToken cancellationToken = default);
}
