using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IEntityService<Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Doctor Create(Doctor doctor) => _doctorRepository.Create(doctor);
        public IEnumerable<Doctor> GetAll() => _doctorRepository.GetAll();
        public Doctor? Get(int id) => _doctorRepository.GetById(id);
        public bool Delete(int id) => _doctorRepository.Delete(id);
        public Doctor? Update(int id, Doctor doctor) => _doctorRepository.Update(id, doctor);
        public void ShowInfo(Doctor doctor)
        {
            Console.WriteLine("-------- Doctor Info --------");
            Console.WriteLine($"ID: {doctor.Id}");
            Console.WriteLine($"Name: {doctor.Name} {doctor.Surname}");
            Console.WriteLine($"Type: {doctor.DoctorType}");
            Console.WriteLine($"Start Date: {doctor.StartDate:yyyy-MM-dd}");
            Console.WriteLine($"Experience: {doctor.GetExperience()} years");
            Console.WriteLine("------------------------------");
        }
    }
}
