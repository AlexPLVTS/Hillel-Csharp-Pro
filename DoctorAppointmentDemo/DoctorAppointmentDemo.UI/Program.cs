using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Enums;
using DoctorAppointmentDemo.Domain.Enums;
using MyDoctorAppointment.Data.Configuration;
using System.Data;
using System;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using DoctorAppointmentDemo.Data.Helper;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Select file format for data (json/xml):");
            var format = Console.ReadLine()?.Trim().ToLower();

            // Decide settings path
            string settingsPath = (format == "xml") ? Constants.AppSettingsPathXML : Constants.AppSettingsPath;

            // Create serializers for each entity
            ISerializer<Doctor> doctorSerializer = (format == "xml")
                ? new XmlEntitySerializer<Doctor>()
                : new JsonEntitySerializer<Doctor>();

            ISerializer<Patient> patientSerializer = (format == "xml")
                ? new XmlEntitySerializer<Patient>()
                : new JsonEntitySerializer<Patient>();

            ISerializer<Appointment> appointmentSerializer = (format == "xml")
                ? new XmlEntitySerializer<Appointment>()
                : new JsonEntitySerializer<Appointment>();

            var doctorRepo = new DoctorRepository(doctorSerializer, settingsPath, format);
            var patientRepo = new PatientRepository(patientSerializer, settingsPath, format);
            var appointmentRepo = new AppointmentRepository(appointmentSerializer, settingsPath, format);

            var doctorService = new DoctorService(doctorRepo);
            var patientService = new PatientService(patientRepo);
            var appointmentService = new AppointmentService(appointmentRepo, doctorRepo, patientRepo);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Manage Doctors");
                Console.WriteLine("2. Manage Patients");
                Console.WriteLine("3. Manage Appointments");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // Manage Doctors
                        ManageDoctors(doctorService);
                        break;
                    case "2": // Manage Patients
                        ManagePatients(patientService);
                        break;
                    case "3": // Manage Appointments
                        ManageAppointments(appointmentService, doctorService, patientService);
                        break;
                    case "4": // Exit
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
        // Doctors start
        static void ManageDoctors(DoctorService doctorService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Doctors ===");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. List Doctors");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDoctor(doctorService);
                        break;
                    case "2":
                        UpdateDoctor(doctorService);
                        break;
                    case "3":
                        DeleteDoctor(doctorService);
                        break;
                    case "4":
                        ListDoctors(doctorService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void ListDoctors(DoctorService service)
        {
            var list = service.GetAll();
            Console.WriteLine($"Total doctors: {list.Count()}");
            foreach (var d in list)
            {
                service.ShowInfo(d);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void AddDoctor(DoctorService doctorService)
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter Doctor Type (e.g., FamilyDoctor): ");
            Enum.TryParse(Console.ReadLine(), true, out DoctorTypes doctorType);
            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
            var doctor = Doctor.Create(name, surname, doctorType, startDate);
            doctorService.Create(doctor);
            Console.WriteLine("Doctor added.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void UpdateDoctor(DoctorService service)
        {
            Console.Write("Doctor ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var doctor = service.Get(id);
                if (doctor != null)
                {
                    Console.Write("Enter new Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter new Surname: ");
                    var surname = Console.ReadLine();
                    Console.Write("Enter new Doctor Type (e.g., FamilyDoctor): ");
                    Enum.TryParse(Console.ReadLine(), true, out DoctorTypes doctorType);
                    Console.Write("Enter new Start Date (yyyy-mm-dd): ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
                    var updatedDoctor = Doctor.Create(name, surname, doctorType, startDate);
                    service.Update(id, updatedDoctor);
                    Console.WriteLine("Doctor updated.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Doctor not found.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void DeleteDoctor(DoctorService service)
        {
            Console.Write("Doctor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var success = service.Delete(id);
                Console.WriteLine(success ? "Doctor deleted." : "Doctor not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        // Doctors stop | Patiens start
        static void ManagePatients(PatientService patientService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Patients ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. List Patients");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddPatient(patientService);
                        break;
                    case "2":
                        UpdatePatient(patientService);
                        break;
                    case "3":
                        DeletePatient(patientService);
                        break;
                    case "4":
                        ListPatients(patientService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void AddPatient(PatientService patientService)
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter Illness Type (e.g., Infection): ");
            Enum.TryParse(Console.ReadLine(), true, out IllnessTypes illnessType);
            var address = Address.Create("123 St", "City", "00001"); // You may want to gather address input similarly
            var patient = Patient.Create(name, surname, illnessType, address);
            patientService.Create(patient);
            Console.WriteLine("Patient added.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void UpdatePatient(PatientService service)
        {
            Console.Write("Patient ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var patient = service.Get(id);
                if (patient != null)
                {
                    Console.Write("Enter new Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter new Surname: ");
                    var surname = Console.ReadLine();
                    Console.Write("Enter new Illness Type (e.g., Infection): ");
                    Enum.TryParse(Console.ReadLine(), true, out IllnessTypes illnessType);
                    var address = patient.Address; // Optionally update address
                    var updatedPatient = Patient.Create(name, surname, illnessType, address, patient.AdditionalInfo);
                    service.Update(id, updatedPatient);
                    Console.WriteLine("Patient updated.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Patient not found.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void DeletePatient(PatientService service)
        {
            Console.Write("Patient ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var success = service.Delete(id);
                Console.WriteLine(success ? "Patient deleted." : "Patient not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void ListPatients(PatientService service)
        {
            var list = service.GetAll();
            Console.WriteLine($"Total Patients: {list.Count()}");
            foreach (var d in list)
            {
                service.ShowInfo(d);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        // Patient stop | Appointment start
        static void ManageAppointments(AppointmentService appointmentService, DoctorService doctorService, PatientService patientService)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Appointments ===");
                Console.WriteLine("1. Schedule Appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. List Appointments");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ScheduleAppointment(patientService, doctorService, appointmentService);
                        break;
                    case "2":
                        CancelAppointment(appointmentService);
                        break;
                    case "3":
                        ListAppointments(appointmentService);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void CancelAppointment(AppointmentService service)
        {
            Console.Write("Enter appointment ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int appointmentId))
            {
                Console.WriteLine("Invalid input. Please enter a numeric ID.");
                return;
            }
            var appointment = service.Get(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }
            Console.WriteLine("Select cancellation reason:");
            foreach (var reason in Enum.GetValues(typeof(CancelationReasons)))
            {
                Console.WriteLine($"{(int)reason}. {reason}");
            }
            Console.Write("Enter reason number: ");
            if (!int.TryParse(Console.ReadLine(), out int reasonNumber) ||
                !Enum.IsDefined(typeof(CancelationReasons), reasonNumber))
            {
                Console.WriteLine("Invalid reason.");
                return;
            }
            var reasonSelected = (CancelationReasons)reasonNumber;
            string canceledBy = "admin";
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
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void ListAppointments(AppointmentService service)
        {
            var list = service.GetAll();
            Console.WriteLine($"Active Appointments: {list.Count()}");
            foreach (var a in list)
            {
                service.ShowInfo(a);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}