using Recruitment.System.Domain.Enum;
using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Entity
{
    public class User : AggregateRoot
    {
        public string ExternalId { get; private set; }
        public UserRole Role { get; private set; }
        public string Email { get; private set; }
        
        public User(string externalId,
            UserRole role,
            string email)
        {
            ExternalId = externalId;
            Role = role;
            Email = email;
        }
    }
}
