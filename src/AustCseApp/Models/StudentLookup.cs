using System.ComponentModel.DataAnnotations;

namespace AustCseApp.Models
{
    public class StudentLookup
    {
        [Required, Display(Name = "Student ID")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Student ID must be exactly 11 digits.")]
        public string StudentId { get; set; } = "";

        [Range(1, 4)]
        public int Year { get; set; }

        [Range(1, 2)]
        public int Semester { get; set; }
    }
}
