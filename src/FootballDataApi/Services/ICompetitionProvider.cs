using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ICompetitionProvider
{
    Task<IEnumerable<Competition>> GetAvailableCompetition();

    Task<IEnumerable<Competition>> GetAvailableCompetitionByArea(int areaId);

    Task<Competition> GetCompetition(int idCompetition);
}
