using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Domain.Helper
{
    public static class Validator
    {
        public static void ThrowIfNullOrWhiteSpace(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{propertyName} is required");
        }
        public static void ThrowIfNull(object value, string propertyName)
        {
            if (value == null)
                throw new ArgumentNullException(propertyName);
        }
        public static void ThrowIfTimeRangeInvalid(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException("Start time must be before end time");
        }

        public static void ThrowIfInPast(DateTime dateTime)
        {
            if (dateTime < DateTime.UtcNow)
                throw new ArgumentException("DateTime cannot be in the past");
        }
    }
}
