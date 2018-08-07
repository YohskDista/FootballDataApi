using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FootballDataApi.Builders
{
    public class MatchProviderBuilder
    {
        private HttpClient _httpClient;

        internal MatchProviderBuilder()
        {

        }

        public MatchProviderBuilder With(HttpClient client)
        {
            _httpClient = client;
            return this;
        }

        public MatchProvider Build()
        {
            return new MatchProvider(_httpClient);
        }
    }
}
