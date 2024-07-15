using FootballDataApi;
using FootballDataApi.Builders;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace FootballRequestConsole;

public class Program
{
    private static object lockWrite = new object();

    public static void Main(string[] args)
    {
        var httpClient = new HttpClient();

        var apiKey = Environment.GetEnvironmentVariable("ApiKey");
        if (!string.IsNullOrEmpty(apiKey))
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
        
        //var competitionController = CompetitionProviderBuilder.Create()
        //    .With(httpClient)
        //    .Build();

        //var matchController = MatchProvider.Create()
        //    .With(httpClient)
        //    .Build();

        //GetCompetitions(competitionController);
        //GetCompetitionsWithFilter(competitionController);
        //GetCompetitionById(competitionController, 2019);
        //GetAllMatchOfCompetition(matchController, 2019);
        //GetAllMatch(matchController);
        //GetMatchById(matchController, 200033);

        Console.ReadKey();
    }

    private static async void GetMatchById(MatchProvider matchController, int idMatch)
    {
        var match = await matchController.GetMatchById(idMatch);

        lock (lockWrite)
        {
            Console.WriteLine("### Get match by ID ###");
            Console.WriteLine(JsonConvert.SerializeObject(match));
            Console.WriteLine();
        }
    }

    private static async void GetAllMatch(MatchProvider matchController)
    {
        var matches = await matchController.GetAllMatches();

        lock (lockWrite)
        {
            Console.WriteLine("### All available matches ###");
            Console.WriteLine(JsonConvert.SerializeObject(matches));
            Console.WriteLine();
        }
    }

    private static async void GetAllMatchOfCompetition(MatchProvider matchController, int id)
    {
        var matches = await matchController.GetAllMatchOfCompetition(id);

        lock (lockWrite)
        {
            Console.WriteLine("### All matches of competition ###");
            Console.WriteLine(JsonConvert.SerializeObject(matches));
            Console.WriteLine();
        }
    }

    private static async void GetCompetitionById(CompetitionProvider competitionController, int id)
    {
        var competition = await competitionController.GetCompetition(id);

        lock (lockWrite)
        {
            Console.WriteLine("### One particular competition ###");
            Console.WriteLine(JsonConvert.SerializeObject(competition));
            Console.WriteLine(); 
        }
    }

    private static async void GetCompetitions(CompetitionProvider competitionController)
    {
        var competitions = await competitionController.GetAvailableCompetition();

        lock (lockWrite)
        {
            Console.WriteLine("### All available competitions ###");
            Console.WriteLine(JsonConvert.SerializeObject(competitions));
            Console.WriteLine(); 
        }
    }

    private static async void GetCompetitionsWithFilter(CompetitionProvider competitionController)
    {
        var competitions = await competitionController.GetAvailableCompetitionByArea(2114);

        lock (lockWrite)
        {
            Console.WriteLine("### Competition of the area X ###");
            Console.WriteLine(JsonConvert.SerializeObject(competitions));
            Console.WriteLine(); 
        }
    }
}
