using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Entity
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
