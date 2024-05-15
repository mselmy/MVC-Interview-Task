using BusinessLogicLayer.Models;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
    }

    public class StudentRepo : IStudentRepo
    {
        private readonly SqlDbContext db;

        public StudentRepo(SqlDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Student>> GetAll()
        {
            return await db.Students.Include(s => s.StudentSubjects).ThenInclude(ss => ss.Subject).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await db.Students.Include(s => s.StudentSubjects).ThenInclude(ss => ss.Subject).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
