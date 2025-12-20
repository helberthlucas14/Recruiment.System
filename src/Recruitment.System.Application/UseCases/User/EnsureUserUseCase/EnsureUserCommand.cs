using MediatR;
using Recruitment.System.Application.UseCases.User.Common;
using Recruitment.System.Domain.Enum;

namespace Recruitment.System.Application.UseCases.User.EnsureUserUseCase
{
    public class EnsureUserCommand 
        : IRequest<UserOutputModel>
    {
        public string ExternalId { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public EnsureUserCommand(
            string externalId,
            UserRole role,
            string email)
        {
            ExternalId = externalId;
            Role = role;
            Email = email;
        }
    }
}
