using BusinessLogicLayer.Models;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ISubjectRepo
    {
        List<Subject> GetAll();
        Subject GetById(int id);
        void Add(Subject entity);
        void Update(Subject entity);
        void Delete(int id);
    }

    internal class SubjectRepo : ISubjectRepo
    {

        private readonly StaticDataContext SD;

        public SubjectRepo(StaticDataContext SD)
        {
            this.SD = SD;
        }

        public void Add(Subject entity)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            throw new NotImplementedException();
        }

        public Subject GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
