using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using FootballDataApi.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.DataSources
{
    public class AreaHttp : IArea
    {
        private static string BaseAddress = "http://api.football-data.org/v2/areas";

        private readonly HttpClient _httpClient;

        public AreaHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            var url = $"{BaseAddress}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var rootArea = await _httpClient.Get<RootArea>(request);

            return rootArea.Areas;
        }

        public async Task<Area> GetAreaById(int idArea)
        {
            var url = $"{BaseAddress}/{idArea}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            return await _httpClient.Get<Area>(request);


        }
    }
}
