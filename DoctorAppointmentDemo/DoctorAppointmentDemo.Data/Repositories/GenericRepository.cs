using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        protected readonly ISerializer<TSource> _serializer;
        protected readonly string _settingsPath;

        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }

        public GenericRepository(ISerializer<TSource> serializer, string settingsPath)
        {
            _serializer = serializer;
            _settingsPath = settingsPath;
        }
        public virtual TSource Create(TSource source)
        {
            source.Id = ++LastId;
            SaveAll(GetAll().Append(source));
            SaveLastId();
            return source;
        }
        public virtual bool Delete(int id)
        {
            var allEntities = GetAll().ToList();
            var entity = allEntities.FirstOrDefault(x => x.Id == id);
            if (entity == null) return false;
            allEntities.Remove(entity);
            SaveAll(allEntities);
            return true;
        }
        public virtual IEnumerable<TSource> GetAll()
        {
            if (!File.Exists(Path))
                _serializer.Serialize(new List<TSource>(), Path);

            return _serializer.Deserialize(Path);
        }
        public virtual TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        public virtual TSource? Update(int id, TSource source)
        {
            var allEntities = GetAll().ToList();
            var index = allEntities.FindIndex(x => x.Id == id);
            if (index == -1) return null;
            source.Id = id;
            allEntities[index] = source;
            SaveAll(allEntities);
            return source;
        }
        private void SaveAll(IEnumerable<TSource> entities)
        {
            _serializer.Serialize(entities.ToList(), Path);
        }
        protected abstract void SaveLastId();
        protected dynamic? ReadFromAppSettingsJson() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(_settingsPath));
        protected XDocument? ReadFromAppSettingsXml() => XDocument.Load(_settingsPath);
    }
}
