using FootballDataApi.Models;
using FootballDataApi.Models.Competitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface ICompetitionProvider
{
    Task<IReadOnlyCollection<Competition>> GetAvailableCompetition();

    Task<IReadOnlyCollection<Competition>> GetAvailableCompetitionByArea(int areaId);

    Task<DetailedCompetition> GetCompetition(string competitionId);
}
