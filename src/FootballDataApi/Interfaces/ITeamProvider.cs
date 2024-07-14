using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces;

public interface ITeamProvider
{
    Task<IEnumerable<Team>> GetTeamByCompetition(int idCompetition, params string[] filters);

    Task<Team> GetTeamById(int idTeam);
}
