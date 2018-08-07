using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FootballDataApi.Builders
{
    public class AreaProviderBuilder
    {
        private HttpClient _httpClient;

        internal AreaProviderBuilder()
        {

        }

        public AreaProviderBuilder With(HttpClient client)
        {
            _httpClient = client;
            return this;
        }

        public AreaProvider Build()
        {
            return new AreaProvider(_httpClient);
        }
    }
}
