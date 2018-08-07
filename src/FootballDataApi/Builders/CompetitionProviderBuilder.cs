using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FootballDataApi.Builders
{
    public class CompetitionProviderBuilder
    {
        private HttpClient _httpClient;

        internal CompetitionProviderBuilder()
        {

        }

        public CompetitionProviderBuilder With(HttpClient client)
        {
            _httpClient = client;
            return this;
        }

        public CompetitionProvider Build()
        {
            return new CompetitionProvider(_httpClient);
        }
    }
}
