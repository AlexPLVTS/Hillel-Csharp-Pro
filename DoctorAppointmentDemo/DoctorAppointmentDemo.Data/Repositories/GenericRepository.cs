using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }
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
            {
                File.WriteAllText(Path, "[]");
            }
            var json = File.ReadAllText(Path);
            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(Path, "[]");
                json = "[]";
            }
            return JsonConvert.DeserializeObject<List<TSource>>(json) ?? new List<TSource>();
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
            File.WriteAllText(Path, JsonConvert.SerializeObject(entities, Formatting.Indented));
        }
        protected abstract void SaveLastId();
        protected dynamic? ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));
    }
}
