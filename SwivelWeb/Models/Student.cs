using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
    }
}
