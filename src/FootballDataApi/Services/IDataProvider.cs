using System.Threading;
using System.Threading.Tasks;

namespace FootballDataApi.Services;

internal interface IDataProvider
{
    Task<T> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default);
}
