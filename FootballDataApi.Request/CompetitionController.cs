using FootballDataApi.Domain;
using FootballDataApi.Request.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Request
{
    public class CompetitionController : ICompetition
    {
        private readonly HttpClient _httpClient;

        public CompetitionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetition(params string[] filters)
        {
            if (filters.Length > 2)
                throw new ArgumentOutOfRangeException();

            var url = $"http://api.football-data.org/v2/competitions";

            if (filters.Length > 0)
                url = $"{url}/?{ string.Join("=", filters) }";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var competitionRoot = await Get<CompetitionRoot>(_httpClient, request);

            return competitionRoot.Competitions;
        }

        public async Task<Competition> GetCompetition(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.football-data.org/v2/competitions/{id}");
            return await Get<Competition>(_httpClient, request);
        }

        private async Task<T> Get<T>(HttpClient httpClient, HttpRequestMessage request)
        {
            using (var response = await httpClient.SendAsync(request, new CancellationToken()))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
