using FootballDataApi;
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
        private static object lockWrite = new object();

        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            if (!string.IsNullOrEmpty(apiKey))
                httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

            var competitionController = new CompetitionController(httpClient);

            GetCompetitions(competitionController);
            GetCompetitionsWithFilter(competitionController);
            GetCompetitionById(competitionController, 2019);

            Console.ReadKey();
        }

        private static async void GetCompetitionById(CompetitionController competitionController, int id)
        {
            var competition = await competitionController.GetCompetition(id);

            lock (lockWrite)
            {
                Console.WriteLine("### One particular competition ###");
                Console.WriteLine(JsonConvert.SerializeObject(competition));
                Console.WriteLine(); 
            }
        }

        private static async void GetCompetitions(CompetitionController competitionController)
        {
            var competitions = await competitionController.GetAvailableCompetition();

            lock (lockWrite)
            {
                Console.WriteLine("### All available competitions ###");
                Console.WriteLine(JsonConvert.SerializeObject(competitions));
                Console.WriteLine(); 
            }
        }

        private static async void GetCompetitionsWithFilter(CompetitionController competitionController)
        {
            var competitions = await competitionController.GetAvailableCompetition("areas", "2114");

            lock (lockWrite)
            {
                Console.WriteLine("### Competition of the area X ###");
                Console.WriteLine(JsonConvert.SerializeObject(competitions));
                Console.WriteLine(); 
            }
        }
    }
}
