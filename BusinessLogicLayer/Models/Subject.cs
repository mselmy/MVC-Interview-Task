using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLogicLayer.Models
{
    public class Subject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id is required.")]
        //[Remote("IsIdAvailable", "Subjects", ErrorMessage = "Id already exists.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+([a-zA-Z\s-]*[a-zA-Z]+)?$", ErrorMessage = "Name can only contain letters, spaces, and hyphens, and cannot start or end with a space.")]
        public string Name { get; set; }

        public virtual List<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
