using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepo,
                                  IDoctorRepository doctorRepo,
                                  IPatientRepository patientRepo)
        {
            _appointmentRepository = appointmentRepo;
            _doctorRepository = doctorRepo;
            _patientRepository = patientRepo;
        }
        public Appointment Schedule(Appointment appointment) => _appointmentRepository.Create(appointment);
        public IEnumerable<Appointment> GetAll() => _appointmentRepository.GetAll();
        public Appointment? Get(int id) => _appointmentRepository.GetById(id);
        public bool Cancel(int id, CancelationReasons reason, string canceledBy)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null) return false;
            appointment.Cancel(reason, canceledBy);
            _appointmentRepository.Update(id, appointment);
            return true;
        }
        public bool Delete(int id) => _appointmentRepository.Delete(id);
        public Appointment? Update(int id, Appointment appointment) => _appointmentRepository.Update(id, appointment);
        public void ShowInfo(Appointment appointment)
        {
            Console.WriteLine("-------- Appointment Info --------");
            Console.WriteLine($"ID: {appointment.Id}");
            Console.WriteLine($"Patient: {appointment.Patient?.Name} {appointment.Patient?.Surname}");
            Console.WriteLine($"Doctor: {appointment.Doctor?.Name} {appointment.Doctor?.Surname}");
            Console.WriteLine($"From: {appointment.DateTimeFrom}");
            Console.WriteLine($"To: {appointment.DateTimeTo}");
            Console.WriteLine($"Description: {appointment.Description}");
            Console.WriteLine($"Canceled: {appointment.IsCanceled}");
            if (appointment.IsCanceled)
            {
                Console.WriteLine($"Cancellation Reason: {appointment.CancelationReason}");
            }
            Console.WriteLine("----------------------------------");
        }
    }
}
