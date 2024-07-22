using FootballDataApi.Models.Standings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IStandingProvider
{
    Task<IReadOnlyCollection<Standing>> GetStandingOfCompetition(int competitionId);
}