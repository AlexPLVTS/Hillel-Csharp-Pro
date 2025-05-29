using DoctorAppointmentDemo.Domain.Enums;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Schedule(Appointment appointment);
        IEnumerable<Appointment> GetAll();
        Appointment? Get(int id);
        bool Cancel(int id, CancelationReasons reason, string canceledBy);
        bool Delete(int id);
        Appointment? Update(int id, Appointment appointment);
    }
}
