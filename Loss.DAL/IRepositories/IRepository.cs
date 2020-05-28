using System.Collections.Generic;

namespace Loss.DAL.IRepositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        T Add(T entity);
        T Update(int id, T entity);
        void Delete(int id);
    }
}
