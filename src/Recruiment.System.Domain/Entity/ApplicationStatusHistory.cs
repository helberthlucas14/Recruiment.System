using Recruiment.System.Domain.Enum;

namespace Recruiment.System.Domain.Entity
{
    public class ApplicationStatusHistory
    {
        public ApplicationStatus Status { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public string ChangedBy { get; private set; }
        public string? Note { get; private set; }
        public ApplicationStatusHistory(
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
