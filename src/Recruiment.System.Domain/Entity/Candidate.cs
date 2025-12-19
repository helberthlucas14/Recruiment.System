using Recruiment.System.Domain.SeedWork;

namespace Recruiment.System.Domain.Entity
{
    public class Candidate : AggregateRoot
    {
        public Guid UserId { get; private set; }

        public Candidate(Guid userId)
        {
            UserId = userId;
        }
    }
}
