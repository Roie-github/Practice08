using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataRepository.BaseClass
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void InsertOnSubmit(T entity);
        void UpdateOnSubmit(T entity);
        void DeleteOnSubmit(int id);
    }
}
