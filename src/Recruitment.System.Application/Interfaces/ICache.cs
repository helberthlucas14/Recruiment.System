using Recruitment.System.Domain.Entity;

namespace Recruitment.System.Application.Interfaces
{
    public interface ICache
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan timeSpan);
    }
}
