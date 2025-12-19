using Recruiment.System.Domain.Enum;
using Recruiment.System.Domain.SeedWork;

namespace Recruiment.System.Domain.Entity
{
    public class User : AggregateRoot
    {
        public string ExternalId { get; private set; } = string.Empty;
        public UserRole Role { get; private set; }
        public string Email { get; private set; }
        
        public User(string externalId, UserRole role, string email)
        {
            ExternalId = externalId;
            Role = role;
            Email = email;
        }
    }
}
