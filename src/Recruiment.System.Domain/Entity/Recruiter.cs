using Recruiment.System.Domain.SeedWork;

namespace Recruiment.System.Domain.Entity
{
    public class Recruiter : AggregateRoot
    {
        public Guid UserId { get; private set; }

        public Recruiter(Guid userId)
        {
            UserId = userId;
        }
    }
}
