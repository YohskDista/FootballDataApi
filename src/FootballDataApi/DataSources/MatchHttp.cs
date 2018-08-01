using System;
using System.Collections.Generic;
using System.Text;
using FootballDataApi.Interfaces;
using System.Net.Http;
using FootballDataApi.Models;
using System.Threading.Tasks;
using System.Linq;
using FootballDataApi.Extensions;

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
            var rootMatches = await _httpClient.Get<RootMatches>(request);

            return rootMatches.Matches;
        }

        public Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            throw new NotImplementedException();
        }

        public Task<Match> GetMatchById(int idMatch)
        {
            throw new NotImplementedException();
        }

        internal sealed class RootMatches
        {
            public int Count { get; set; }
            public object Filters { get; set; }
            public IEnumerable<Match> Matches { get; set; }
        }
    }
}
