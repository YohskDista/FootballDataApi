using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ICompetitionProvider
{
    Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetition();

    Task<IReadOnlyCollection<AvailableCompetition>> GetAvailableCompetitionByArea(int areaId);

    Task<DetailedCompetition> GetCompetition(string competitionId);
}
