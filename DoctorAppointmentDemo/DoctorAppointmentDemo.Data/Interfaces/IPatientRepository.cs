using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        //string PreviousAppointments(int patientId) надає інформацію якщо пацієнт уже звертався

        //IEnumerable<Patient> GetByType(IllnessType type) фільтр по типу захворювання

        //IEnumerable<Patient> GetByPriority(PriorityLevel level) фільтр по пріорітету
    }
}
