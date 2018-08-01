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
                var rootMatches = JsonConvert.DeserializeObject<RootMatches>(matches);
                listMatchMockup = rootMatches.Matches;
            }
        }

        public Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
        {
            var authorizedFilters = new string[] { "competitions", "dateFrom", "dateTo", "status" };

            var intermediateList = listMatchMockup;

            if(filters.Contains("competitions"))
            {
                var indexCompetitionValue = Array.IndexOf(filters, "competitions") + 1;
                intermediateList = intermediateList
                    .Where(T => T.Competition.Id == int.Parse(filters.ElementAt(indexCompetitionValue)));
            }

            if (filters.Contains("dateFrom"))
            {
                var indexDateFromValue = Array.IndexOf(filters, "dateFrom") + 1;
                intermediateList = intermediateList
                    .Where(T => T.UtcDate >= DateTime.Parse(filters.ElementAt(indexDateFromValue)));
            }

            if (filters.Contains("dateTo"))
            {
                var indexDateToValue = Array.IndexOf(filters, "dateTo") + 1;
                intermediateList = intermediateList
                    .Where(T => T.UtcDate <= DateTime.Parse(filters.ElementAt(indexDateToValue)));
            }

            if (filters.Contains("status"))
            {
                var indexStatusValue = Array.IndexOf(filters, "status") + 1;
                intermediateList = intermediateList
                    .Where(T => T.Status == filters.ElementAt(indexStatusValue));
            }

            return Task.Run(() => intermediateList);
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
