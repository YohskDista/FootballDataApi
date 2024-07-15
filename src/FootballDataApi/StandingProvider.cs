using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class StandingProvider : IStandingProvider
{
    private readonly HttpClient _httpClient;

    public StandingProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public Task<SeasonStanding> GetStandingOfCompetition(int competitionId)
    {
        HttpHelpers.VerifyActionParameters(competitionId, null, null);

        return _httpClient.GetAsync<SeasonStanding>($"competitions/{competitionId}/standings");
    }
}
