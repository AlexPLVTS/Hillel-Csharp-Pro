using DoctorAppointmentDemo.Domain.Helper;
using System.Text.Json.Serialization;
namespace MyDoctorAppointment.Domain.Entities
{
    public abstract class UserBase : Auditable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public UserBase(string name, string surname, string? phone = null, string? email = null)
        {
            Validator.ThrowIfNullOrWhiteSpace(name, nameof(Name));
            Validator.ThrowIfNullOrWhiteSpace(surname, nameof(Surname));
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
        }
    }
}
