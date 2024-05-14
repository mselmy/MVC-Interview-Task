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

    public class SubjectRepo : ISubjectRepo
    {

        private readonly StaticDataContext SD;

        public SubjectRepo(StaticDataContext SD)
        {
            this.SD = SD;
        }

        public void Add(Subject entity)
        {
            SD.subjects.Add(entity);
        }

        public void Delete(int id)
        {
            Subject subject = GetById(id);
            if (subject != null)
            {
                SD.subjects.Remove(subject);
            }
        }

        public List<Subject> GetAll()
        {
            return SD.subjects;
        }

        public Subject GetById(int id)
        {
            return SD.subjects.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Subject entity)
        {
            Subject subject = GetById(entity.Id);
            if (subject != null)
            {
                subject.Name = entity.Name;
            }
        }
    }
}
