
using DoctorAppointmentDemo.Domain.Helper;
using DoctorAppointmentDemo.Domain.Enums;
namespace MyDoctorAppointment.Domain.Entities
{
    public class Appointment : Auditable
    {
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string? Description { get; set; }
        public CancelationReasons CancelationReason { get; set; }
        public Appointment(Patient patient, Doctor doctor, DateTime from, DateTime to, string? description = null)
        {
            Validator.ThrowIfNull(patient, nameof(Patient));
            Validator.ThrowIfNull(doctor, nameof(Doctor));
            Validator.ThrowIfNullOrWhiteSpace(description ?? string.Empty, nameof(Description));
            Validator.ThrowIfTimeRangeInvalid(from, to);
            Validator.ThrowIfInPast(from);
            Patient = patient;
            Doctor = doctor;
            DateTimeFrom = from;
            DateTimeTo = to;
            Description = description;
            MarkAsCreated("system");
        }
        public static Appointment Schedule(Patient patient, Doctor doctor, DateTime from, DateTime to, string? description = null)
        {
            return new Appointment(patient, doctor, from, to, description);
        }
        public void Reschedule(DateTime newFrom, DateTime newTo)
        {
            Validator.ThrowIfNull(newFrom, nameof(newFrom));
            Validator.ThrowIfNull(newTo, nameof(newTo));
            Validator.ThrowIfTimeRangeInvalid(newFrom, newTo);
            Validator.ThrowIfInPast(newFrom);
            DateTimeFrom = newFrom;
            DateTimeTo = newTo;
            MarkAsUpdated("system");
        }
        public void Cancel(CancelationReasons reason, string canceledBy)
        {
            CancelationReason = reason;
            MarkAsCanceled(canceledBy);
        }
    }
}
