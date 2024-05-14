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
        IStudentRepo StudentRepo { get; }
        ISubjectRepo SubjectRepo { get; }
    }

    public class UOW : IUnitOfWork
    {
        private readonly StaticDataContext SD;
        public IStudentRepo studentRepo;
        public ISubjectRepo subjectRepo;

        public UOW(StaticDataContext SD)
        {
            this.SD = SD;
        }

        public IStudentRepo StudentRepo
        {
            get
            {
                if(studentRepo == null)
                {
                    studentRepo = new StudentRepo(SD);
                }
                return studentRepo;
            }
        }

        public ISubjectRepo SubjectRepo
        {
            get
            {
                if (subjectRepo == null)
                {
                    subjectRepo = new SubjectRepo(SD);
                }
                return subjectRepo;
            }
        }
    }
}
