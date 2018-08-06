using FootballDataApi.Extensions;
using FootballDataApi.Interfaces;
using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi
{
    public class TeamController
    {
        private readonly ITeam _teamSource;

        public TeamController(ITeam teamSource)
        {
            _teamSource = teamSource;
        }

        public async Task<IEnumerable<Team>> GetTeamByCompetition(int idCompetition, params string[] filters)
        {
            string[] authorizedFilters = new string[] { "stage" };

            HttpHelpers.VerifyActionParameters(idCompetition, filters, authorizedFilters);

            return await _teamSource.GetTeamByCompetition(idCompetition, filters);
        }

        public async Task<Team> GetTeamById(int idTeam)
        {
            HttpHelpers.VerifyActionParameters(idTeam, null, null);

            return await _teamSource.GetTeamById(idTeam);
        }
    }
}
