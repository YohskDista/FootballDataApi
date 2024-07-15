using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IMatchProvider
{
    Task<IEnumerable<Match>> GetAllMatches(params string[] filters);

    Task<IEnumerable<Match>> GetAllMatchOfCompetition(int competitionId, params string[] filters);

    Task<IEnumerable<Match>> GetAllMatchOfTeam(int teamId, params string[] filters);

    Task<Match> GetMatchById(int matchId);
}
