using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces
{
    public interface ICompetition
    {
        Task<IEnumerable<Competition>> GetAvailableCompetition();

        Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId);

        Task<Competition> GetCompetition(int id);
    }
}
