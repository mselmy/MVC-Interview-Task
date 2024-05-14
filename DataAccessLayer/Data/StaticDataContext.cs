using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace DataAccessLayer.Data
{
    public class StaticDataContext
    {
        public StaticDataContext()
        {
            subjects.Add(new Subject { Id = 1, Name = "Arabic" });
            subjects.Add(new Subject { Id = 2, Name = "English" });
            subjects.Add(new Subject { Id = 3, Name = "Science" });
            subjects.Add(new Subject { Id = 4, Name = "History" });

            students.Add(new Student { Id = 1, Name = "Ahmed", Date = new DateOnly(2000, 1, 1), Address = "Cairo", Subjects = [subjects[0], subjects[1]] });
            students.Add(new Student { Id = 2, Name = "Ali", Date = new DateOnly(2001, 2, 2), Address = "Giza", Subjects = [subjects[2], subjects[3]] });
            students.Add(new Student { Id = 3, Name = "Mohamed", Date = new DateOnly(2002, 3, 3), Address = "Alex", Subjects = [subjects[0], subjects[2]] });
            students.Add(new Student { Id = 4, Name = "Omar", Date = new DateOnly(2003, 4, 4), Address = "Aswan", Subjects = [subjects[1], subjects[3]] });
            students.Add(new Student { Id = 5, Name = "Mahmoud", Date = new DateOnly(2004, 5, 5), Address = "Luxor", Subjects = [subjects[0], subjects[3]] });
        }

        public List<Subject> subjects { get; } = new List<Subject>();

        public List<Student> students { get; } = new List<Student>();
    }
}
