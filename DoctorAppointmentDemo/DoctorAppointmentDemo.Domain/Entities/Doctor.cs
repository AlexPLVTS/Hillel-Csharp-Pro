using MyDoctorAppointment.Domain.Enums;
using System.Text.Json.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }
        public DateTime StartDate { get; set; }
        public Doctor () { }
        public Doctor(string name, string surname, DoctorTypes doctorType, DateTime startDate) : base(name, surname)
        {
            DoctorType = doctorType;
            StartDate = startDate;
        }
        public static Doctor Create(string name, string surname, DoctorTypes doctorType, DateTime startDate)
        {
            return new Doctor(name, surname, doctorType, startDate);
        }
        public int GetExperience()
        {
            return DateTime.Now.Year - StartDate.Year;
        }
    }
}
