using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;

namespace BusinessLogicLayer.Repositories
{
    internal interface IGenericRepo<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
    }

    StaticDataContext
}
