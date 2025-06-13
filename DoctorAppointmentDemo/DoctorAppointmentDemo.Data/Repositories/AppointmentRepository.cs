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
        private string _format;
        public AppointmentRepository(ISerializer<Appointment> serializer, string settingsPath, string format)
        : base(serializer, settingsPath)
        {
            _format = format;

            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                Path = result.Database.Appointments.Path;
                LastId = result.Database.Appointments.LastId;
            }
            else // xml
            {
                var doc = ReadFromAppSettingsXml();
                Path = doc.Root.Element("Appointments").Element("Path").Value;
                LastId = int.Parse(doc.Root.Element("Appointments").Element("LastId").Value);
            }
        }
        protected override void SaveLastId()
        {
            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                result.Database.Appointments.LastId = LastId;
                File.WriteAllText(_settingsPath, result.ToString());
            }
            else
            {
                var doc = ReadFromAppSettingsXml();
                doc.Root.Element("Appointments").Element("LastId").Value = LastId.ToString();
                doc.Save(_settingsPath);
            }
        }
    }
}
