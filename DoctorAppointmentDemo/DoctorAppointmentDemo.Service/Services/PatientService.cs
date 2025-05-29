using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Services
{
    public class PatientService : IEntityService<Patient>
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public Patient Create(Patient patient) => _patientRepository.Create(patient);
        public IEnumerable<Patient> GetAll() => _patientRepository.GetAll();
        public Patient? Get(int id) => _patientRepository.GetById(id);
        public bool Delete(int id) => _patientRepository.Delete(id);
        public Patient? Update(int id, Patient patient) => _patientRepository.Update(id, patient);
        public void ShowInfo(Patient patient)
        {
            Console.WriteLine("-------- Patient Info --------");
            Console.WriteLine($"ID: {patient.Id}");
            Console.WriteLine($"Name: {patient.Name} {patient.Surname}");
            Console.WriteLine($"Illness: {patient.IllnessType}");
            Console.WriteLine($"Address: {patient.Address.Street}, {patient.Address.City} {patient.Address.ZipCode}");
            Console.WriteLine("------------------------------");
        }
    }
}
