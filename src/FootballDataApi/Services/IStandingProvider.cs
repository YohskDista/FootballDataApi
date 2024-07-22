using FootballDataApi.Models.Standings;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IStandingProvider
{
    Task<IReadOnlyCollection<Standing>> GetStandingOfCompetitionAsync(
        string competitionId, 
        CancellationToken cancellationToken = default);
}