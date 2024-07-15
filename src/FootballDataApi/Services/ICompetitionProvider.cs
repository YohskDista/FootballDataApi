using FootballDataApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ICompetitionProvider
{
    Task<IReadOnlyCollection<Competition>> GetAvailableCompetition();

    Task<IReadOnlyCollection<Competition>> GetAvailableCompetitionByArea(int areaId);

    Task<Competition> GetCompetition(int competitionId);
}
