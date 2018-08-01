using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            if (filters.Length > 0 && filters.Length % 2 != 0)
                throw new ArgumentException("Respect key / value parameters.");

            return await _matchCommands.GetAllMatches(filters);
        }

        public async Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters)
        {
            if (idTeam < 0)
                throw new ArgumentException("ID of the team cannot be negative");

            if (filters.Length % 2 != 0)
                throw new ArgumentException("Respect the key / value in filters (args=value)");

            throw new NotImplementedException();
        }

        public async Task<Match> GetMatchById(int idMatch)
        {
            if (idMatch < 0)
                throw new ArgumentException("ID of the match cannot be negative");

            return await _matchCommands.GetMatchById(idMatch);
        }
    }
}