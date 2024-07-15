using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;

namespace FootballDataApi;

internal sealed class MatchProvider : IMatchProvider
{
    private static string BaseAddress = "http://api.football-data.org/v2/matches";

    private readonly HttpClient _httpClient;

    public MatchProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
    {
        var authorizedFilters = new string[] { "competitions", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyFilters(filters, authorizedFilters);

        var urlMatches = "matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _httpClient.GetAsync<RootMatch>(urlMatches);

        return rootMatches.Matches;
    }

    public async Task<IEnumerable<Match>> GetAllMatchOfCompetition(int competitionId, params string[] filters)
    {
        var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

        HttpHelpers.VerifyActionParameters(competitionId, filters, authorizedFilters);

        var urlMatches = "matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _httpClient.GetAsync<RootMatch>(urlMatches);

        return rootMatches.Matches;
    }

    public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int teamId, params string[] filters)
    {
        var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyActionParameters(teamId, filters, authorizedFilters);

        var urlMatches = $"teams/{teamId}/matches";

        if (filters.Length > 0)
        {
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);
        }

        var rootMatches = await _httpClient.GetAsync<RootMatch>(urlMatches);

        return rootMatches.Matches;
    }

    public Task<Match> GetMatchById(int matchId)
    {
        HttpHelpers.VerifyActionParameters(matchId, null, null);

        return _httpClient.GetAsync<Match>($"matches/{matchId}");
    }
}