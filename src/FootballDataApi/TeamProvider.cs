using FootballDataApi.Builders;
using FootballDataApi.Extensions;
using FootballDataApi.Models;
using FootballDataApi.Services;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi;

internal sealed class TeamProvider : ITeamProvider
{
    private readonly HttpClient _httpClient;

    internal TeamProvider(HttpClient httpClient)
        => _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<IEnumerable<Team>> GetTeamByCompetition(int idCompetition, params string[] filters)
    {
        string[] authorizedFilters = new string[] { "stage" };

        HttpHelpers.VerifyActionParameters(idCompetition, filters, authorizedFilters);

        var urlTeamByCompetition = $"http://api.football-data.org/v2/competitions/{idCompetition}/teams";

        urlTeamByCompetition = HttpHelpers.AddFiltersToUrl(urlTeamByCompetition, filters);

        var request = new HttpRequestMessage(HttpMethod.Get, urlTeamByCompetition);
        var TeamRoot = await _httpClient.Get<RootTeam>(request);

        return TeamRoot.Teams;
    }

    public async Task<Team> GetTeamById(int idTeam)
    {
        HttpHelpers.VerifyActionParameters(idTeam, null, null);

        var urlTeamByCompetition = $"http://api.football-data.org/v2/teams/{idTeam}";

        var request = new HttpRequestMessage(HttpMethod.Get, urlTeamByCompetition);
        var Team = await _httpClient.Get<Team>(request);

        return Team;
    }

    public static TeamProviderBuilder Create()
    {
        return new TeamProviderBuilder();
    }
}
