using MediatR;
using Recruitment.System.Application.Interfaces;
using Recruitment.System.Application.UseCases.User.Common;
using Recruitment.System.Domain.Repository;
using DomainEntity = Recruitment.System.Domain.Entity;

namespace Recruitment.System.Application.UseCases.User.EnsureUserUseCase
{
    public class EnsureUserCommandHandler :
        IRequestHandler<EnsureUserCommand, UserOutputModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICache _cache;
        public EnsureUserCommandHandler(
            IUserRepository userRepository,
            ICache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<UserOutputModel> Handle(EnsureUserCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"user:{request.ExternalId}";

            var user = await _cache.GetAsync<DomainEntity.User>(cacheKey) ??
                await _userRepository.GetAsyncByExternalId(request.ExternalId, cancellationToken);

            if (user is null)
            {
                user = new DomainEntity.User(
                    request.ExternalId,
                    request.Role,
                    request.Email);

                await _userRepository.InsertAsync(user, cancellationToken);
            }

            await _cache.SetAsync(
                request.ExternalId,
                user,
                TimeSpan.FromMinutes(30));

            return UserOutputModel.FromUser(user);
        }
    }
}
