﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Domain.Enums
{
    public enum CancelationReasons
    {
        PatienRequest = 1,
        DoctorRequest,
        ScheduleConflict,
        Emergency,
        Other
    }
}
