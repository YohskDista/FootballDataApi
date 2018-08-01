using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;

namespace FootballDataApi
{
    public class MatchController
    {
        private readonly IMatch _matchCommands;

        public MatchController(IMatch matchCommands)
        {
            _matchCommands = matchCommands;
        }

        public async Task<IEnumerable<Match>> GetAllMatches(params string[] filters)
        {
            var authorizedFilters = new string[] { "competitions", "dateFrom", "dateTo", "status" };

            if (filters.Length % 2 != 0)
                throw new ArgumentException("Respect key / value parameters.");

            if (filters != null)
            {
                var parametersNotPresent = authorizedFilters.IsFilterPresentInList(filters).ToList();

                if(parametersNotPresent.Count > 0)
                    throw new ArgumentException($"This filters are not supported : \n { string.Join("\n", parametersNotPresent) }");
            }

            return await _matchCommands.GetAllMatches(filters);
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

            if (idTeam < 0)
                throw new IndexOutOfRangeException("ID of the team cannot be negative");

            if (filters.Length % 2 != 0)
                throw new ArgumentException("Respect the key / value in filters (args=value)");

            if (filters != null)
            {
                var parametersNotPresent = authorizedFilters.IsFilterPresentInList(filters).ToList();

                if (parametersNotPresent.Count > 0)
                    throw new ArgumentException($"This filters are not supported : \n { string.Join("\n", parametersNotPresent) }");
            }

            throw new NotImplementedException();
        }

        public async Task<Match> GetMatchById(int idMatch)
        {
            if (idMatch < 0)
                throw new IndexOutOfRangeException("ID of the match cannot be negative");

            return await _matchCommands.GetMatchById(idMatch);
        }
    }
}