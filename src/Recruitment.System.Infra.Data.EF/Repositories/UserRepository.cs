using Microsoft.EntityFrameworkCore;
using Recruitment.System.Application.Exceptions;
using Recruitment.System.Domain.Entity;
using Recruitment.System.Domain.Repository;
using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Infra.Data.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RSContext _context;
        private DbSet<User> _users => _context.Set<User>();
        public UserRepository(RSContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var notafiscal = await _users
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            NotFoundException.ThrowIfNull(notafiscal, $"User '{id}' not found.");

            return notafiscal!;
        }

        public async Task<User> GetAsyncByExternalId(string externalId, CancellationToken cancellationToken)
        {
            var notafiscal = await _users.AsNoTracking()
                 .FirstOrDefaultAsync(x => x.ExternalId == externalId, cancellationToken);

            NotFoundException.ThrowIfNull(notafiscal, $"User '{externalId}' not found.");

            return notafiscal!;
        }

        public async Task<User> InsertAsync(User entity, CancellationToken cancellationToken)
        {
            await _users.AddAsync(entity, cancellationToken);
            return entity;
        }

        public Task UpdateAsync(User entity, CancellationToken _)
        {
            return Task.FromResult(_users.Update(entity));
        }

        public Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            user.SoftDelete();
            _context.Users.Update(user);
            return Task.CompletedTask;
        }
    }
}
