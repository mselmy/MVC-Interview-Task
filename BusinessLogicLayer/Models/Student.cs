using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateOnly Date { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
