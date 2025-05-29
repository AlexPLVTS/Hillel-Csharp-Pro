using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            var config = ReadFromAppSettings();
            Path = config.Database.Appointments.Path;
            LastId = config.Database.Appointments.LastId;
        }
        protected override void SaveLastId()
        {
            var config = ReadFromAppSettings();
            config.Database.Appointments.LastId = LastId;
            File.WriteAllText(Constants.AppSettingsPath, config.ToString());
        }
    }
}
