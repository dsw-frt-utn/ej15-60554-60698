using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEF : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;
        public PersistenceEF(Dsw2026Ej15DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Speciality>> GetByAllSpecialityAsync()
        {
            return _context.Specialities;
        }

        public async Task<IEnumerable<Doctor>> GetByAllDoctorsAsync()
        {
            return _context.Doctors
                .Include(d => d.Speciality)
                .Where(d => d.IsActive);
        }

        public async Task<Doctor?> GetByIdDoctorAsync(Guid id)
        {
            return await _context.Doctors
                .Include(d => d.Speciality)
                .FirstOrDefaultAsync(d => d.Id == id && d.IsActive);
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            doctor.IsActive = false;
            _context.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<Speciality?> GetByIdSpecialityAsync(Guid id)
        {
            return await _context.Specialities.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
