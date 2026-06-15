using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data.Interfaces
{
    public interface IPersistence<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);

    }
}
