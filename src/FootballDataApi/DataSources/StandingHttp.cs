using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.DataSources
{
    public class StandingHttp : IStanding
    {
        private readonly HttpClient _httpClient;

        public StandingHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SeasonStanding> GetStandingOfCompetition(int idCompetition)
        {
            var urlStanding = $"http://api.football-data.org/v2/competitions/{idCompetition}/standings";

            var request = new HttpRequestMessage(HttpMethod.Get, urlStanding);

            return await _httpClient.Get<SeasonStanding>(request);
        }
    }
}
