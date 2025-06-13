using DoctorAppointmentDemo.Domain.Helper;
using MyDoctorAppointment.Domain.Enums;
using System.IO;
using System.Reflection.Emit;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }
        public string? AdditionalInfo { get; set; }
        public Address Address { get; set; }
        public Patient() { }
        public Patient(string name, string surname, IllnessTypes illnessType, Address address, string? additionalInfo = null) 
                        : base(name, surname)
        {
            Validator.ThrowIfNull(address, nameof(Address));
            IllnessType = illnessType;
            Address = address;
            AdditionalInfo = additionalInfo;
        }
        public static Patient Create(string name, string surname, IllnessTypes illnessType, Address address, string? additionalInfo = null)
        {
            return new Patient(name, surname, illnessType, address, additionalInfo);
        }
        public void UpdateAddress(Address newAddress)
        {
            Validator.ThrowIfNull(newAddress, nameof(newAddress));
            Address = newAddress;
        }
        public void UpdateAdditionalInfo(string? info)
        {
            AdditionalInfo = info;
        }
        public void UpdateIllnessType(IllnessTypes illnessType)
        {
            IllnessType = illnessType;
        }
    }
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Address() { }
        public Address(string street, string city, string zipCode) 
        {
            Validator.ThrowIfNullOrWhiteSpace(street, nameof(Street));
            Validator.ThrowIfNullOrWhiteSpace(city, nameof(City));
            Validator.ThrowIfNullOrWhiteSpace(zipCode, nameof(ZipCode));

            Street = street;
            City = city;
            ZipCode = zipCode;
        }
        public static Address Create(string street, string city, string zipCode)
        {
            return new Address(street, city, zipCode);
        }
    }
}
