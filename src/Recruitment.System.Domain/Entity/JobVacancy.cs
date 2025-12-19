using Recruitment.System.Domain.Enum;
using Recruitment.System.Domain.Exceptions;
using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Entity
{
    public class JobVacancy : AggregateRoot
    {
        public Guid RecruiterId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public JobStatus Status { get; private set; }

        public JobVacancy(Guid recruiterId, string title, string description)
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
