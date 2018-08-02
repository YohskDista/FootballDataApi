using System;
using System.Collections.Generic;
using System.Text;
using FootballDataApi.Interfaces;
using System.Net.Http;
using FootballDataApi.Models;
using System.Threading.Tasks;
using System.Linq;
using FootballDataApi.Extensions;
using FootballDataApi.Utilities;

namespace FootballDataApi.DataSources
{
    public class MatchHttp : IMatch
    {
        private static string BaseAddress = "http://api.football-data.org/v2/matches";

        private readonly HttpClient _httpClient;

        public MatchHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
        {                
            var urlMatches = BaseAddress;

            if (filters.Length > 0)
                urlMatches = HttpExtensions.AddFiltersToUrl(urlMatches, filters);

            var request = new HttpRequestMessage(HttpMethod.Get, urlMatches);
            var rootMatches = await _httpClient.Get<RootMatch>(request);

            return rootMatches.Matches;
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            var urlAreas = $"http://api.football-data.org/v2/competitions/{idCompetition}/matches";

            if (filters.Length > 0)
                urlAreas = HttpExtensions.AddFiltersToUrl(urlAreas, filters);

            var request = new HttpRequestMessage(HttpMethod.Get, urlAreas);
            var competitionMatches = await _httpClient.Get<CompetitionMatches>(request);

            return competitionMatches.Matches;
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            var urlMatches = $"http://api.football-data.org/v2/teams/{idTeam}/matches";

            if (filters.Length > 0)
                urlMatches = HttpExtensions.AddFiltersToUrl(urlMatches, filters);

            var request = new HttpRequestMessage(HttpMethod.Get, urlMatches);
            var rootMatches = await _httpClient.Get<RootMatch>(request);

            return rootMatches.Matches;
        }

        public async Task<Match> GetMatchById(int idMatch)
        {
            var urlMatch = $"{BaseAddress}/{idMatch}";

            var request = new HttpRequestMessage(HttpMethod.Get, urlMatch);
            return await _httpClient.Get<Match>(request);
        }
    }
}
