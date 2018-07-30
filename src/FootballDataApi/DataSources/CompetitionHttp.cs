using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.DataSources
{
    public class CompetitionHttp : ICompetition
    {
        private static string BaseAddress = "http://api.football-data.org/v2/competitions";

        private readonly HttpClient _httpClient;

        public CompetitionHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetition()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BaseAddress);
            var competitionRoot = await Get<CompetitionRoot>(_httpClient, request);

            return competitionRoot.Competitions;
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
        {
            var urlAreas = $"{BaseAddress}/?areas={ areaId }";

            var request = new HttpRequestMessage(HttpMethod.Get, urlAreas);
            var competitionRoot = await Get<CompetitionRoot>(_httpClient, request);

            return competitionRoot.Competitions;
        }

        public async Task<Competition> GetCompetition(int idCompetition)
        {
            var url = $"{BaseAddress}/{idCompetition}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

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
