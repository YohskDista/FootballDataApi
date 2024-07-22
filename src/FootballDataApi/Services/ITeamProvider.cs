using FootballDataApi.Models;
using FootballDataApi.Models.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ITeamProvider
{
    Task<IReadOnlyCollection<FullDetailedTeam>> GetTeamByCompetition(
        int competitionId, 
        params string[] filters);

    Task<FullDetailedTeam> GetTeamById(int teamId);
}
