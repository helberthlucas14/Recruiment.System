using Recruiment.System.Domain.Enum;
using Recruiment.System.Domain.Exceptions;
using Recruiment.System.Domain.SeedWork;

namespace Recruiment.System.Domain.Entity
{
    public class JobApplication : AggregateRoot
    {
        public Guid RecuiterId { get; private set; }
        public Guid JobVacationId { get; private set; }
        public Guid CandidateId { get; private set; }
        public ApplicationStatus CurrentStatus { get; private set; }
        public IReadOnlyCollection<ApplicationStatusHistory> Histories => _history;

        private readonly List<ApplicationStatusHistory> _history = new();
        protected JobApplication() : base() { }

        public JobApplication(Guid recuiterId,
            Guid jobVacationId,
            Guid candidateId)
        {
            RecuiterId = recuiterId;
            JobVacationId = jobVacationId;
            CandidateId = candidateId;
            AddHistory(CurrentStatus, "Created");
        }

        public void ChangeStatus(ApplicationStatus newStatus,
            Guid changedBy,
            string? note = null)
        {
            var invalidTransition = !IsValidTransition(CurrentStatus, newStatus);

            if (invalidTransition)
                throw new EntityValidationException(
                    $"Transitin from {CurrentStatus} to {newStatus} is not allowed."
                    );

            CurrentStatus = newStatus;
            AddHistory(newStatus, changedBy, note);
        }

        private bool IsValidTransition(ApplicationStatus current, ApplicationStatus next)
        {
            return current switch
            {
                ApplicationStatus.Applied => next == ApplicationStatus.InReview || next == ApplicationStatus.Rejected,
                ApplicationStatus.InReview => next == ApplicationStatus.Interview || next == ApplicationStatus.Rejected,
                ApplicationStatus.Interview => next == ApplicationStatus.Offered || next == ApplicationStatus.Rejected,
                ApplicationStatus.Offered => next == ApplicationStatus.Hired || next == ApplicationStatus.Rejected,
                ApplicationStatus.Hired => false,
                ApplicationStatus.Rejected => false,
                _ => false
            };
        }

        public void AddHistory(ApplicationStatus status,
            string changedBy,
            string? note = null)
        {
            _history.Add(new ApplicationStatusHistory(
                status,
                changedBy,
                note
                ));
        }
    }
}
