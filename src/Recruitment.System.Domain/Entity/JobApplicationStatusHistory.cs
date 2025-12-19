using Recruitment.System.Domain.Enum;
using Recruitment.System.Domain.SeedWork;

namespace Recruitment.System.Domain.Entity
{
    public class JobApplicationStatusHistory : AggregateRoot
    {
        public ApplicationStatus Status { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public string ChangedBy { get; private set; }
        public string? Note { get; private set; }
        public JobApplicationStatusHistory(
            ApplicationStatus status,
            string changedBy,
            string? note)
        {
            Status = status;
            ChangedBy = changedBy;
            Note = note;
            ChangedAt = DateTime.Now;
        }
    }
}
