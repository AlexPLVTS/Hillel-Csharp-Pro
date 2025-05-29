using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            var doctorRepo = new DoctorRepository();
            var doctorService = new DoctorService(doctorRepo);
            var patientRepo = new PatientRepository();
            var patientService = new PatientService(patientRepo);
            var appointmentRepo = new AppointmentRepository();
            var appointmentService = new AppointmentService(appointmentRepo, doctorRepo, patientRepo);
            var defaultDoctor = Doctor.Create("Ivan", "Ivanivskyy", DoctorTypes.FamilyDoctor, new DateTime(2015, 1, 15));
            doctorService.Create(defaultDoctor);
            Console.WriteLine("Default doctor added.\n");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. List Doctors");
                Console.WriteLine("3. List Patients");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. List Appointments");
                Console.WriteLine("6. Show Doctor Details");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // Add Patient
                        AddPatient(patientService);
                        break;
                    case "2": // List Doctors
                        ListDoctors(doctorService);
                        break;
                    case "3": // List Patients
                        ListPatients(patientService);
                        break;
                    case "4": // Schedule Appointment
                        ScheduleAppointment(patientService, doctorService, appointmentService);
                        break;
                    case "5": // List Appointments
                        ListAppointments(appointmentService);
                        break;
                    case "6": // Show Doctor Details
                        ShowDoctorDetails(doctorService);
                        break;
                    case "7": // Exit
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Program ended.");
        }
        static void AddPatient(PatientService patientService)
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            var surname = Console.ReadLine();
            var address = Address.Create("123 St", "City", "00001");
            var patient = Patient.Create(name, surname, IllnessTypes.Infection, address);
            patientService.Create(patient);
            Console.WriteLine("Patient added.");
        }
        static void ListDoctors(DoctorService service)
        {
            var list = service.GetAll();
            Console.WriteLine($"Total doctors: {list.Count()}");
            foreach (var d in list)
            {
                service.ShowInfo(d);
            }
        }
        static void ListPatients(PatientService service)
        {
            var list = service.GetAll();
            Console.WriteLine($"Total patients: {list.Count()}");
            foreach (var p in list)
            {
                service.ShowInfo(p);
            }
        }
        static void ScheduleAppointment(PatientService patSvc, DoctorService docSvc, AppointmentService appSvc)
        {
            Console.Write("Patient ID: ");
            if (int.TryParse(Console.ReadLine(), out int pId))
            {
                var patient = patSvc.Get(pId);
                if (patient == null)
                {
                    Console.WriteLine("Patient not found");
                    return;
                }
                Console.Write("Doctor ID: ");
                if (int.TryParse(Console.ReadLine(), out int dId))
                {
                    var doctor = docSvc.Get(dId);
                    if (doctor == null)
                    {
                        Console.WriteLine("Doctor not found");
                        return;
                    }
                    var from = DateTime.Now.AddDays(1);
                    var to = from.AddHours(1);
                    var appointment = Appointment.Schedule(patient, doctor, from, to, "Checkup");
                    appSvc.Schedule(appointment);
                    Console.WriteLine("Appointment scheduled.");
                }
            }
        }
        static void ListAppointments(AppointmentService service)
        {
            var list = service.GetAll();
            foreach (var a in list)
            {
                service.ShowInfo(a);
            }
        }
        static void ShowDoctorDetails(DoctorService service)
        {
            Console.Write("Doctor ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var d = service.Get(id);
                if (d != null)
                    service.ShowInfo(d);
                else
                    Console.WriteLine("Doctor not found");
            }
        }
    }
}