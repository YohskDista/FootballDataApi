using FootballDataApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Request.Interfaces
{
    public interface ICompetition
    {
        Task<IEnumerable<Competition>> GetAvailableCompetition();

        Task<Competition> GetCompetition(int id);
    }
}
