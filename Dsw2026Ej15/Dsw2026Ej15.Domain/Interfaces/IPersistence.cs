using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task<Speciality?> GetByIdSpecialityAsync(Guid id);
        Task<List<Speciality>> GetByAllSpecialityAsync();
        Task<List<Doctor>> GetByAllDoctorsAsync();
        Task<Doctor?> GetByIdDoctorAsync(Guid id);
        void AddDoctor(Doctor newDoctor);
        void DeleteDoctor(Doctor doctor);
    }
}