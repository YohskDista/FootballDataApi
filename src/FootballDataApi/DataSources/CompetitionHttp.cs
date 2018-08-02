using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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

        public async Task<IEnumerable<Competition>> GetAvailableCompetition()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BaseAddress);
            var competitionRoot = await _httpClient.Get<RootCompetitions>(request);

            return competitionRoot.Competitions;
        }

        public async Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId)
        {
            var urlAreas = $"{BaseAddress}/?areas={ areaId }";

            var request = new HttpRequestMessage(HttpMethod.Get, urlAreas);
            var competitionRoot = await _httpClient.Get<RootCompetitions>(request);

            return competitionRoot.Competitions;
        }

        public async Task<Competition> GetCompetition(int idCompetition)
        {
            var url = $"{BaseAddress}/{idCompetition}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            return await _httpClient.Get<Competition>(request);
        }
    }
}
