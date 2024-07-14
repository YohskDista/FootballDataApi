using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.StandingTests;

public class StandingSource : IStandingProvider
{
    private SeasonStanding seasonStandingMockup;

    public StandingSource()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "FootballDataApi.Tests.Data.StandingData.json";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string standings = reader.ReadToEnd();
            var seasonStanding = JsonConvert.DeserializeObject<SeasonStanding>(standings);
            seasonStandingMockup = seasonStanding;
        }
    }

    public Task<SeasonStanding> GetStandingOfCompetition(int idCompetition)
    {
        HttpHelpers.VerifyActionParameters(idCompetition, null, null);

        return Task.Run(() => seasonStandingMockup);
    }
}
