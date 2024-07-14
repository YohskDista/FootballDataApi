using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.MatchTests;

public class MatchSource : IMatchProvider
{
    private IEnumerable<Match> listMatchMockup;

    public MatchSource()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "FootballDataApi.Tests.Data.MatchData.json";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string matches = reader.ReadToEnd();
            var rootMatches = JsonConvert.DeserializeObject<RootMatch>(matches);
            listMatchMockup = rootMatches.Matches;
        }
    }

    public Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
    {
        var authorizedFilters = new string[] { "competitions", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyFilters(filters, authorizedFilters);

        return Task.Run(() => listMatchMockup);
    }

    public Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
    {
        var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

        HttpHelpers.VerifyActionParameters(idCompetition, filters, authorizedFilters);

        return Task.Run(() => listMatchMockup.Where(T => T.Competition.Id == idCompetition));
    }

    public Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
    {
        var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

        HttpHelpers.VerifyActionParameters(idTeam, filters, authorizedFilters);

        return Task.Run(() => listMatchMockup.Where(T => T.AwayTeam.Id == idTeam || T.HomeTeam.Id == idTeam));
    }

    public Task<Match> GetMatchById(int idMatch)
    {
        HttpHelpers.VerifyActionParameters(idMatch, null, null);

        return Task.Run(() => listMatchMockup.FirstOrDefault(T => T.Id == idMatch));
    }
}
