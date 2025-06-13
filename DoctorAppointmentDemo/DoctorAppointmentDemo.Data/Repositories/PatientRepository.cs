using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }
        private string _format;
        public PatientRepository(ISerializer<Patient> serializer, string settingsPath, string format)
        : base(serializer, settingsPath)
        {
            _format = format;
            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                Path = result.Database.Patients.Path;
                LastId = result.Database.Patients.LastId;
            }
            else // xml
            {
                var doc = ReadFromAppSettingsXml();
                Path = doc.Root.Element("Patients").Element("Path").Value;
                LastId = int.Parse(doc.Root.Element("Patients").Element("LastId").Value);
            }
        }
        protected override void SaveLastId()
        {
            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                result.Database.Patients.LastId = LastId;
                File.WriteAllText(_settingsPath, result.ToString());
            }
            else
            {
                var doc = ReadFromAppSettingsXml();
                doc.Root.Element("Patients").Element("LastId").Value = LastId.ToString();
                doc.Save(_settingsPath);
            }
        }
    }
}
