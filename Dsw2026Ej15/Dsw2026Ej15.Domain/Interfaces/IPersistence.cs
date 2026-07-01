using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task<Speciality?> GetByIdSpecialityAsync(Guid id);
        Task<IEnumerable<Speciality>> GetByAllSpecialityAsync();
        Task<IEnumerable<Doctor>> GetByAllDoctorsAsync();
        Task<Doctor?> GetByIdDoctorAsync(Guid id);
        Task AddDoctor(Doctor newDoctor);
        Task DeleteDoctor(Doctor doctor);
    }
}