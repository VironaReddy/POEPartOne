using System.ComponentModel.DataAnnotations;

namespace POEOne.Models
{
    public class Lecturer
    {
        [Key]
        [Display(Name = "Lecturer ID")]
        public int LecturerID { get; set; }

        [Display(Name = "Lecturer Name")]
        public string? LecturerName { get; set; }

        [Display(Name = "Lecturer Email")]
        public string? LecturerEmail { get; set; }

        [Display(Name = "Hours Taught")]
        public int HoursTaught { get; set; }

        [Display(Name = "Rate per Hour")] // keeps records of hours worked and horly rated
        public double Rate { get; set; }

        [Display(Name = "Month Taught")]
        public string? Month { get; set; }
    }
}

    
