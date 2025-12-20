using Recruitment.System.Domain.Enum;
using DomainEntity = Recruitment.System.Domain.Entity;

namespace Recruitment.System.Application.UseCases.User.Common
{
    public class UserOutputModel
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }

        public UserOutputModel(
            Guid id,
            string externalId,
            UserRole role,
            string email)
        {
            Id = id;
            ExternalId = externalId;
            Role = role;
            Email = email;
        }


        public static UserOutputModel FromUser(DomainEntity.User user)
        {
            return new UserOutputModel(
                user.Id,
                user.ExternalId,
                user.Role,
                user.Email);
        }
    }
}
