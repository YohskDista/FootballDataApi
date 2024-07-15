using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IMatchProvider
{
    Task<IEnumerable<Match>> GetAllMatches(params string[] filters);

    Task<IEnumerable<Match>> GetAllMatchOfCompetition(int idCompetition, params string[] filters);

    Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters);

    Task<Match> GetMatchById(int idMatch);
}
