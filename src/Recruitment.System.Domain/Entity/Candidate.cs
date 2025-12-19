using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Entity
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
