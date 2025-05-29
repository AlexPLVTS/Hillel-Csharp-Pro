using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        //Методи будуть добавлені в майбутньому
        
        //IEnumerable<Doctor> GetByType(DoctorTypes type); фільтр по типу

        //IEnumerable<Doctor> GetAvailableOnDate(DateTime date); фільтр по доступності

        //IEnumerable<Doctor> GetByExperience(int minimumYears); фільтр по досвіду роботи

        //bool ExistsWithSpecialty(DoctorTypes type); перевірка чи існує доктор типу

        //bool IsDoctorAvailable(int doctorId, DateTime appointmentTime); перевірка чи доктор доступний на данний час
    }
}
