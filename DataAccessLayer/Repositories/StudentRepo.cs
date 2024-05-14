using BusinessLogicLayer.Models;
using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student entity);
        void Update(Student entity);
        void Delete(int id);
    }

    internal class StudentRepo : IStudentRepo
    {
        StaticDataContext SD;

        public StudentRepo(StaticDataContext SD)
        {
            this.SD = SD;
        }

        public void Add(Student entity)
        {
            SD.students.Add(entity);
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            if (student != null)
            {
                SD.students.Remove(student);
            }
        }

        public List<Student> GetAll()
        {
            return SD.students;
        }

        public Student GetById(int id)
        {
            return SD.students.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Student entity)
        {
            Student student = GetById(entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Date = entity.Date;
                student.Address = entity.Address;
                student.Subjects = entity.Subjects;
            }
        }
    }
}
