using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }
        private string _format;
        public DoctorRepository(ISerializer<Doctor> serializer, string settingsPath, string format)
        : base(serializer, settingsPath)
        {
            _format = format;

            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                Path = result.Database.Doctors.Path;
                LastId = result.Database.Doctors.LastId;
            }
            else // xml
            {
                var doc = ReadFromAppSettingsXml();
                Path = doc.Root.Element("Doctors").Element("Path").Value;
                LastId = int.Parse(doc.Root.Element("Doctors").Element("LastId").Value);
            }
        }
        protected override void SaveLastId()
        {
            if (_format == "json")
            {
                var result = ReadFromAppSettingsJson();
                result.Database.Doctors.LastId = LastId;
                File.WriteAllText(_settingsPath, result.ToString());
            }
            else
            {
                var doc = ReadFromAppSettingsXml();
                doc.Root.Element("Doctors").Element("LastId").Value = LastId.ToString();
                doc.Save(_settingsPath);
            }
        }
    }
}
