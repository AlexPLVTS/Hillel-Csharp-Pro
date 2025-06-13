using DoctorAppointmentDemo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Helper
{
    public class XmlEntitySerializer<T> : ISerializer<T>
    {
        public List<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                try
                {
                    return (List<T>)serializer.Deserialize(stream);
                }
                catch
                {
                    return new List<T>();
                }
            }
        }
        public void Serialize(List<T> items, string filePath)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, items);
            }
        }
    }
}
