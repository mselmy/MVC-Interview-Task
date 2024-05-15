using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }

    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly SqlDbContext context;
        public GenericRepo(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            context.Set<T>().Add(entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await Save();
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }

    //public class StaticListGenericRepo<T> : IGenericRepo<T> where T : class
    //{
    //    private readonly StaticDataContext SD;
    //    public StaticListGenericRepo(StaticDataContext SD)
    //    {
    //        this.SD = SD;
    //    }

    //    private List<T> GetDataSet()
    //    {
    //        PropertyInfo property = SD.GetType().GetProperties()
    //            .FirstOrDefault(p => p.PropertyType == typeof(List<T>));
    //        return property?.GetValue(SD) as List<T>;
    //    }

    //    public void Add(T entity)
    //    {
    //        var set = GetDataSet();
    //        if (set != null)
    //        {
    //            set.Add(entity);
    //        }
    //    }

    //    public void Delete(int id)
    //    {
    //        var set = GetDataSet();
    //        if (set != null)
    //        {
    //            T entity = GetById(id);
    //            if (entity != null)
    //            {
    //                set.Remove(entity);
    //            }
    //        }
    //    }

    //    public List<T> GetAll()
    //    {
    //        var set = GetDataSet();
    //        return set?.ToList() ?? new List<T>();
    //    }

    //    public T GetById(int id)
    //    {
    //        var set = GetDataSet();
    //        if (set != null)
    //        {
    //            PropertyInfo idProperty = typeof(T).GetProperty("Id");
    //            if (idProperty != null)
    //            {
    //                return set.FirstOrDefault(e => (int)idProperty.GetValue(e) == id);
    //            }
    //        }
    //        return null;
    //    }

    //    public void Update(T entity)
    //    {

    //        var set = GetDataSet();
    //        if (set != null)
    //        {
    //            PropertyInfo idProperty = typeof(T).GetProperty("Id");
    //            if (idProperty != null)
    //            {
    //                int id = (int)idProperty.GetValue(entity);
    //                T existing = GetById(id);
    //                if (existing != null)
    //                {
    //                    int index = set.IndexOf(existing);
    //                    set[index] = entity;
    //                }
    //            }
    //        }
    //    }
    //}
}
