using FootballDataApi.Extensions;
using FootballDataApi.Models.Standings;
using FootballDataApi.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class StandingProvider : IStandingProvider
{
    private readonly HttpClient _httpClient;

    public StandingProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IReadOnlyCollection<Standing>> GetStandingOfCompetitionAsync(
        string competitionId, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(competitionId);

        var standingsRoot = await _httpClient.GetAsync<StandingsRoot>(
            $"competitions/{competitionId}/standings",
            cancellationToken);

        return standingsRoot.Standings;
    }
}
