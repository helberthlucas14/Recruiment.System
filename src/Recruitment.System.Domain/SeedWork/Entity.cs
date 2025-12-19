namespace Recruitment.System.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        protected void SoftDelete()
        {
            IsDeleted = true;
        }
        protected void Restore()
        {
            IsDeleted = false;
        }
    }
}
