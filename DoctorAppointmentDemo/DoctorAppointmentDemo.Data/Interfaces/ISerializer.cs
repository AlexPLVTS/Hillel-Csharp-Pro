using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface ISerializer<T>
    {
        List<T> Deserialize(string filePath);
        void Serialize(List<T> items, string filePath);
    }
}
