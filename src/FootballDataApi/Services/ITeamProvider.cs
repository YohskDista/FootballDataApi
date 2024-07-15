using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ITeamProvider
{
    Task<IEnumerable<Team>> GetTeamByCompetition(int competitionId, params string[] filters);

    Task<Team> GetTeamById(int teamId);
}
