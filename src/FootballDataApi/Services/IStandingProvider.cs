using FootballDataApi.Models;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

public interface IStandingProvider
{
    Task<SeasonStanding> GetStandingOfCompetition(int competitionId);
}