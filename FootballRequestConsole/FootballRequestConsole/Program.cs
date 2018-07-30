using FootballDataApi.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FootballRequestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            if (!string.IsNullOrEmpty(apiKey))
                httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

            //GetCompetitions(httpClient);
            GetCompetitionById(httpClient, 2019);

            Console.ReadKey();
        }

        private static async void GetCompetitionById(HttpClient httpClient, int id)
        {
            var competitionController = new CompetitionController(httpClient);

            var competition = await competitionController.GetCompetition(id);

            Console.WriteLine(JsonConvert.SerializeObject(competition));
        }

        private static async void GetCompetitions(HttpClient httpClient)
        {
            var competitionController = new CompetitionController(httpClient);

            var competitions = await competitionController.GetAvailableCompetition();

            Console.WriteLine(JsonConvert.SerializeObject(competitions));
        }
    }
}
