using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        List<Speciality> _specialities = [];
        List<Doctor> _doctors = [];
        public PersistenceInMemory()
        {
            LoadSpecialities();
        }

        public async Task<List<Speciality>> GetByAllSpecialityAsync()
        {
            return _specialities;
        }

        private void LoadSpecialities()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
                var json = File.ReadAllText(jsonPath);
                var specialities = JsonSerializer.Deserialize<List<Speciality>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if (specialities != null)
                    _specialities = specialities;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar especialidades: {ex.Message}");
            }
        }

        public async Task<List<Doctor>> GetByAllDoctorsAsync()
        {
            return _doctors;
        }

        public async Task<Doctor?> GetByIdDoctorAsync(Guid id)
        {
            return _doctors.SingleOrDefault(e => e.Id == id);
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            doctor.IsActive = false;
        }

        public Task<Speciality?> GetByIdSpecialityAsync(Guid id)
        {
            return Task.FromResult(_specialities.SingleOrDefault(s => s.Id == id));
        }

        Task<IEnumerable<Speciality>> IPersistence.GetByAllSpecialityAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Doctor>> IPersistence.GetByAllDoctorsAsync()
        {
            throw new NotImplementedException();
        }
    }   
}
