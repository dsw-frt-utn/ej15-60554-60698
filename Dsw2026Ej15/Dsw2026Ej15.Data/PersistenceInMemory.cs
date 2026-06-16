using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence<Doctor>, IPersistence<Speciality>
    {
        public void Add(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Speciality entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Speciality entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Speciality> IPersistence<Speciality>.GetAll()
        {
            throw new NotImplementedException();
        }

        Speciality? IPersistence<Speciality>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        private List<Speciality>? LoadSpecialities()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
                var json = File.ReadAllTextAsync(jsonPath);
                var specialities = JsonSerializer.Deserialize<List<Speciality>>(json.Result);
                return specialities;
            }
            catch
            {
                return null;
            }
        }
    }
}
