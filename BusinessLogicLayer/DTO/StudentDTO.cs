using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string Address { get; set; }

        public List<int> SelectedSubjectIds { get; set; } = new List<int>();

        public List<Subject> AvailableSubjects { get; set; }
    }
}
