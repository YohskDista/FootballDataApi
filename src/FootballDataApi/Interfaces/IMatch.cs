using FootballDataApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces
{
    public interface IMatch
    {
        Task<IEnumerable<Match>> GetAllMatchFrom(int idCompetition, params string[] filters);

        Task<IEnumerable<Match>> GetAllMatchOfTeam(int idTeam, params string[] filters);

        Task<Match> GetMatchById(int idMatch);
    }
}
