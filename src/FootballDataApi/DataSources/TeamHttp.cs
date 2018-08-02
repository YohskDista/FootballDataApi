using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.DataSources
{
    public class TeamHttp : ITeam
    {
        private readonly HttpClient _httpClient;

        public TeamHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Team>> GetTeamByCompetition(int idCompetition, params string[] filters)
        {
            var urlTeamByCompetition = $"http://api.football-data.org/v2/competitions/{idCompetition}/teams";

            urlTeamByCompetition = HttpExtensions.AddFiltersToUrl(urlTeamByCompetition, filters);

            var request = new HttpRequestMessage(HttpMethod.Get, urlTeamByCompetition);
            var TeamRoot = await _httpClient.Get<RootTeam>(request);

            return TeamRoot.Teams;
        }

        public async Task<Team> GetTeamById(int idTeam)
        {
            HttpExtensions.VerifyActionParameters(idTeam, null, null);

            var urlTeamByCompetition = $"http://api.football-data.org/v2/teams{idTeam}";

            var request = new HttpRequestMessage(HttpMethod.Get, urlTeamByCompetition);
            var Team = await _httpClient.Get<Team>(request);

            return Team;
        }
    }
}
