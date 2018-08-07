using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using FootballDataApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Tests.TeamTests
{
    public class TeamSource : ITeamProvider
    {
        private RootTeam _rootTeam;

        public TeamSource()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "FootballDataApi.Tests.Data.TeamData.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string matches = reader.ReadToEnd();
                var rootTeams = JsonConvert.DeserializeObject<RootTeam>(matches);
                _rootTeam = rootTeams;
            }
        }

        public Task<IEnumerable<Team>> GetTeamByCompetition(int idCompetition, params string[] filters)
        {
            string[] authorizedFilters = new string[] { "stage" };

            HttpHelpers.VerifyActionParameters(idCompetition, filters, authorizedFilters);

            return Task.Run(() => _rootTeam.Teams);
        }

        public Task<Team> GetTeamById(int idTeam)
        {
            HttpHelpers.VerifyActionParameters(idTeam, null, null);

            return Task.Run(() => _rootTeam.Teams
                .FirstOrDefault(T => T.Id == idTeam));
        }
    }
}
