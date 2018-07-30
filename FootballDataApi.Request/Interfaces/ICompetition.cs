using FootballDataApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Request.Interfaces
{
    public interface ICompetition
    {
        Task<IEnumerable<Competition>> GetAvailableCompetition(params string[] filters);

        Task<Competition> GetCompetition(int id);
    }
}
