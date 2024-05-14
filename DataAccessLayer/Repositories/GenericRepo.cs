using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;


namespace DataAccessLayer.Repositories
{
    internal interface IGenericRepo<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly StaticDataContext SD;
        public GenericRepo(StaticDataContext SD)
        {
            this.SD = SD;
        }

        private List<T> GetDataSet()
        {
            PropertyInfo property = SD.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(List<T>));
            return property?.GetValue(SD) as List<T>;
        }

        public void Add(T entity)
        {
            var set = GetDataSet();
            if (set != null)
            {
                set.Add(entity);
            }
        }

        public void Delete(int id)
        {
            var set = GetDataSet();
            if (set != null)
            {
                T entity = GetById(id);
                if (entity != null)
                {
                    set.Remove(entity);
                }
            }
        }

        public List<T> GetAll()
        {
            var set = GetDataSet();
            return set?.ToList() ?? new List<T>();
        }

        public T GetById(int id)
        {
            var set = GetDataSet();
            if (set != null)
            {
                PropertyInfo idProperty = typeof(T).GetProperty("Id");
                if (idProperty != null)
                {
                    return set.FirstOrDefault(e => (int)idProperty.GetValue(e) == id);
                }
            }
            return null;
        }

        public void Update(T entity)
        {

            var set = GetDataSet();
            if (set != null)
            {
                PropertyInfo idProperty = typeof(T).GetProperty("Id");
                if (idProperty != null)
                {
                    int id = (int)idProperty.GetValue(entity);
                    T existing = GetById(id);
                    if (existing != null)
                    {
                        int index = set.IndexOf(existing);
                        set[index] = entity;
                    }
                }
            }
        }
    }
}
