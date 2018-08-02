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

namespace FootballDataApi.Tests.MatchTests
{
    public class MatchSource : IMatch
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
            return Task.Run(() => listMatchMockup);
        }

        public Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            return Task.Run(() => listMatchMockup.Where(T => T.Competition.Id == idCompetition));
        }

        public Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            return Task.Run(() => listMatchMockup.Where(T => T.AwayTeam.Id == idTeam || T.HomeTeam.Id == idTeam));
        }

        public Task<Match> GetMatchById(int idMatch)
        {
            return Task.Run(() => listMatchMockup.FirstOrDefault(T => T.Id == idMatch));
        }
    }
}
