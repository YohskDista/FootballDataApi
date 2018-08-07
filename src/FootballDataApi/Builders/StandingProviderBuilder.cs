using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FootballDataApi.Builders
{
    public class StandingProviderBuilder
    {
        private HttpClient _httpClient;

        internal StandingProviderBuilder()
        {

        }

        public StandingProviderBuilder With(HttpClient client)
        {
            _httpClient = client;
            return this;
        }

        public StandingProvider Build()
        {
            return new StandingProvider(_httpClient);
        }
    }
}
