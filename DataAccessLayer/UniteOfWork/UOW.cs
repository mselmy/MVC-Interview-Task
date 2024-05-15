using BusinessLogicLayer.Models;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UniteOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepo StudentRepoInc { get; }
        IGenericRepo<Student> StudentRepo { get; }
        IGenericRepo<Subject> SubjectRepo { get; }
    }

    public class UOW : IUnitOfWork
    {
        private readonly SqlDbContext db;
        IStudentRepo StudentRepoIncl;
        public IGenericRepo<Student> studentRepo;
        public IGenericRepo<Subject> subjectRepo;

        public UOW(SqlDbContext db)
        {
            this.db = db;
        }

        public IStudentRepo StudentRepoInc
        {
            get
            {
                if (StudentRepoIncl == null)
                {
                    StudentRepoIncl = new StudentRepo(db);
                }
                return StudentRepoIncl;
            }
        }

        public IGenericRepo<Student> StudentRepo
        {
            get
            {
                if(studentRepo == null)
                {
                    studentRepo = new GenericRepo<Student>(db);
                }
                return studentRepo;
            }
        }

        public IGenericRepo<Subject> SubjectRepo
        {
            get
            {
                if (subjectRepo == null)
                {
                    subjectRepo = new GenericRepo<Subject>(db);
                }
                return subjectRepo;
            }
        }
    }
}
