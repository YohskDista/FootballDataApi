using FootballDataApi.Builders;
using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class StandingProvider : IStandingProvider
    {
        private readonly HttpClient _httpClient;

        internal StandingProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SeasonStanding> GetStandingOfCompetition(int idCompetition)
        {
            HttpHelpers.VerifyActionParameters(idCompetition, null, null);

            var urlStanding = $"http://api.football-data.org/v2/competitions/{idCompetition}/standings";

            var request = new HttpRequestMessage(HttpMethod.Get, urlStanding);

            return await _httpClient.Get<SeasonStanding>(request);
        }

        public static StandingProviderBuilder Create()
        {
            return new StandingProviderBuilder();
        }
    }
}
