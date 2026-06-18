using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public required string Name { get; init; }
        public required string LicenseNumber { get; init; }
        public bool IsActive { get; set; }
        public Speciality? Speciality { get; private set; }

        [SetsRequiredMembers]
        public Doctor(string name, string licenseNumber, Speciality specility, bool isActive = true) : base()
        {
            Name = name;
            LicenseNumber = licenseNumber;
            Speciality = specility;
            IsActive = isActive;
        }
    }
}
