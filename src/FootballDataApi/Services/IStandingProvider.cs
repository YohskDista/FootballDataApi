using FootballDataApi.Models.Standings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IStandingProvider
{
    Task<IReadOnlyCollection<Standing>> GetStandingOfCompetitionAsync(
        string competitionId,
        int? seasonYear = null,
        int? matchDay = null,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Standing>> GetStandingAtAsync(
        string competitionId, 
        DateTime date, 
        CancellationToken cancellationToken = default);
}