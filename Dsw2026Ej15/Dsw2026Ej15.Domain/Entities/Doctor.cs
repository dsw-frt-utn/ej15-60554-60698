using Dsw2026Ej15.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public required string Name { get; set; }
        public required string LicenseNumber { get; set; }
        public bool IsActive { get; set; }
        public Speciality? Speciality { get; set; }

        [SetsRequiredMembers]
        public Doctor(string name, string licenseNumber, Speciality specility, bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("El nombre del doctor es obligatorio.");

            if (string.IsNullOrWhiteSpace(licenseNumber))
                throw new ValidationException("La licencia del doctor es obligatoria.");

            Name = name;
            LicenseNumber = licenseNumber;
            Speciality = specility;
            IsActive = isActive;
        }
    }
}
