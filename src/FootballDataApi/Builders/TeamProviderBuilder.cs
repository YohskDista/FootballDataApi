using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FootballDataApi.Builders
{
    public class TeamProviderBuilder
    {
        private HttpClient _httpClient;

        internal TeamProviderBuilder()
        {

        }

        public TeamProviderBuilder With(HttpClient client)
        {
            _httpClient = client;
            return this;
        }

        public TeamProvider Build()
        {
            return new TeamProvider(_httpClient);
        }
    }
}
