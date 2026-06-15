using Dsw2026Ej15.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        [SetsRequiredMembers]
        public Speciality(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ValidationException("El nombre de la especialidad es obligatorio.");


            Name = name;
            Description = description;
        }
    }
}
