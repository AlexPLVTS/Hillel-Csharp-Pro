using DoctorAppointmentDemo.Domain.Helper;
namespace MyDoctorAppointment.Domain.Entities
{
    public abstract class Auditable
    {
        public int Id { get; set; }
        public DateTime CanceledAt { get; set; }
        public bool IsCanceled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? CanceledBy { get; set; }
        public void MarkAsCreated(string createdBy)
        {
            Validator.ThrowIfNullOrWhiteSpace(createdBy, nameof(CreatedBy));
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }
        public void MarkAsUpdated(string updatedBy)
        {
            Validator.ThrowIfNullOrWhiteSpace(updatedBy, nameof(UpdatedBy));
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }
        public void MarkAsDeleted(string deletedBy)
        {
            Validator.ThrowIfNullOrWhiteSpace(deletedBy, nameof(DeletedBy));
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            DeletedBy = deletedBy;
        }
        public void MarkAsCanceled(string canceledBy)
        {
            Validator.ThrowIfNullOrWhiteSpace(canceledBy, nameof(CanceledBy));
            IsCanceled = true;
            CanceledAt = DateTime.UtcNow;
            CanceledBy = canceledBy;
        }
    }
}
