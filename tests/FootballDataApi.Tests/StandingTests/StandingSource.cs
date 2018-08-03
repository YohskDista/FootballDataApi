using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.StandingTests
{
    public class StandingSource : IStanding
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
            return Task.Run(() => seasonStandingMockup);
        }
    }
}
