using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+([a-zA-Z\s-]*[a-zA-Z]+)?$", ErrorMessage = "Name can only contain letters, spaces, and hyphens, and cannot start or end with a space.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateOnly Date { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MinLength(3, ErrorMessage = "Address must be at least 10 characters long.")]
        [MaxLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        [RegularExpression(@"^[^\s]+(\s+[^\s]+)*$", ErrorMessage = "Address cannot start or end with spaces.")]
        public string Address { get; set; }

        [Display(Name = "Subjects")]
        public ICollection<int> SubjectsId { get; set; } = new HashSet<int>();
    }
}
