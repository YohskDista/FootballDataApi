using FootballDataApi.Models;
using System.Threading.Tasks;

namespace FootballDataApi.Interfaces
{
    public interface IStanding
    {
        Task<SeasonStanding> GetStandingOfCompetition(int idCompetition);
    }
}