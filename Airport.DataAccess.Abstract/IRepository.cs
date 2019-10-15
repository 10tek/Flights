using Airport.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.DataAccess.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T element);
        void Delete(Guid elementId);
        void Update(T element);
        ICollection<T> GetAll();
    }
}
