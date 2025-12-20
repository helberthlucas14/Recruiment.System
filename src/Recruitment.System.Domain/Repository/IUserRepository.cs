using Recruitment.System.Domain.Entity;
using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Repository
{
    public interface IUserRepository
        : IGenericRepository<User>
    {
        Task<User> GetAsyncByExternalId(string externalId, CancellationToken cancellationToken);
    }

}
