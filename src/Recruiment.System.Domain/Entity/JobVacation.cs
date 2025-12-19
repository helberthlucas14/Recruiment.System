using Recruiment.System.Domain.Enum;
using Recruiment.System.Domain.Exceptions;
using Recruiment.System.Domain.SeedWork;

namespace Recruiment.System.Domain.Entity
{
    public class JobVacation : AggregateRoot
    {
        public Guid RecruiterId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public JobStatus Status { get; private set; }

        public JobVacation(Guid recruiterId, string title, string description)
        {
            Title = title;
            Description = description;
            Status = JobStatus.Open;
            RecruiterId = recruiterId;
        }

        public void Close()
        {
            if (Status == JobStatus.Closed)
                throw new EntityValidationException("Vacancy is closed.");

            Status = JobStatus.Closed;
        }

        public void Reopen() => Status = JobStatus.Open;
    }
}
