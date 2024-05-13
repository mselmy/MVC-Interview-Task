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
        static List<Subject> subjects = new List<Subject>
        {
            new Subject { Id = 1, Name = "Arabic" },
            new Subject { Id = 2, Name = "English" },
            new Subject { Id = 3, Name = "Science" },
            new Subject { Id = 4, Name = "History" },
        };

        List<Student> students = new List<Student>
        {
            new Student 
            { 
                Id = 1, 
                Name = "Ahmed", 
                Date = new DateOnly(1990, 1, 1), 
                Address = "Cairo", 
                Subjects = [ subjects[0], subjects[1]]
            },

            new Student
            {
                Id = 2,
                Name = "Ali",
                Date = new DateOnly(1995, 2, 2),
                Address = "Giza",
                Subjects = [subjects[2], subjects[3]]
            },

            new Student
            {
                Id = 3,
                Name = "Mohamed",
                Date = new DateOnly(2000, 3, 3),
                Address = "Alex",
                Subjects = [subjects[0], subjects[2]]
            },

            new Student
            {
                Id = 4,
                Name = "Omar",
                Date = new DateOnly(2005, 4, 4),
                Address = "Aswan",
                Subjects = [subjects[1], subjects[3]]
            },

            new Student
            {
                Id = 5,
                Name = "Khaled",
                Date = new DateOnly(2010, 5, 5),
                Address = "Luxor",
                Subjects = [subjects[0], subjects[3]]
            }
        };
    }
}
