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

            HttpExtensions.VerifyFilters(filters, authorizedFilters);

            return await _matchCommands.GetAllMatches(filters);
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters)
        {
            var authorizedFilters = new string[] { "dateFrom", "dateTo", "stage", "status", "matchday", "group" };

            HttpExtensions.VerifyActionParameters(idCompetition, filters, authorizedFilters);

            return await _matchCommands.GetAllMatchOfCompetition(idCompetition, filters);
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            var authorizedFilters = new string[] { "venue", "dateFrom", "dateTo", "status" };

            HttpExtensions.VerifyActionParameters(idTeam, filters, authorizedFilters);

            return await _matchCommands.GetAllMatchOfTeam(idTeam, filters);
        }

        public async Task<Match> GetMatchById(int idMatch)
        {
            HttpExtensions.VerifyActionParameters(idMatch, null, null);

            return await _matchCommands.GetMatchById(idMatch);
        }
    }
}