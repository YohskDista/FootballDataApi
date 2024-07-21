using FootballDataApi.Models.Standings;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IStandingProvider
{
    Task<Standing> GetStandingOfCompetition(int competitionId);
}