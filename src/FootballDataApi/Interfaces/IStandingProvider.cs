using FootballDataApi.Models;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces;

public interface IStandingProvider
{
    Task<SeasonStanding> GetStandingOfCompetition(int idCompetition);
}