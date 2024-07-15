using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FootballDataApi.Builders;
using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;

namespace FootballDataApi;

public sealed class MatchProvider : IMatchProvider
{
    private static string BaseAddress = "http://api.football-data.org/v2/matches";

    private readonly HttpClient _httpClient;

    internal MatchProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
    {
        var authorizedFilters = new string[] { "competitions", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyFilters(filters, authorizedFilters);

        var urlMatches = BaseAddress;

        if (filters.Length > 0)
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);

        var request = new HttpRequestMessage(HttpMethod.Get, urlMatches);
        var rootMatches = await _httpClient.Get<RootMatch>(request);

        return rootMatches.Matches;
    }

    public async Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
    {
        var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

        HttpHelpers.VerifyActionParameters(idCompetition, filters, authorizedFilters);

        var urlMatches = BaseAddress;

        if (filters.Length > 0)
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);

        var request = new HttpRequestMessage(HttpMethod.Get, urlMatches);
        var rootMatches = await _httpClient.Get<RootMatch>(request);

        return rootMatches.Matches;
    }

    public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
    {
        var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyActionParameters(idTeam, filters, authorizedFilters);

        var urlMatches = $"http://api.football-data.org/v2/teams/{idTeam}/matches";

        if (filters.Length > 0)
            urlMatches = HttpHelpers.AddFiltersToUrl(urlMatches, filters);

        var request = new HttpRequestMessage(HttpMethod.Get, urlMatches);
        var rootMatches = await _httpClient.Get<RootMatch>(request);

        return rootMatches.Matches;
    }

    public async Task<Match> GetMatchById(int idMatch)
    {
        HttpHelpers.VerifyActionParameters(idMatch, null, null);

        var urlMatch = $"{BaseAddress}/{idMatch}";

        var request = new HttpRequestMessage(HttpMethod.Get, urlMatch);
        return await _httpClient.Get<Match>(request);
    }

    public static MatchProviderBuilder Create()
    {
        return new MatchProviderBuilder();
    }
}