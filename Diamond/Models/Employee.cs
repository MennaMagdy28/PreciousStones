using System.ComponentModel.DataAnnotations;

namespace Diamond.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You have to provide a valid full name.")]
        [MinLength(10, ErrorMessage ="Full name MUST NOT be less than 10 characters.")]
        [MaxLength(50, ErrorMessage = "Full name MUST NOT be exceed 50 characters.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "You have to provide a valid position.")]
        [MinLength(10, ErrorMessage = "Position MUST NOT be less than 10 characters.")]
        [MaxLength(50, ErrorMessage = "Position MUST NOT be exceed 50 characters.")]
        public string Position { get; set; }
        [Range(6000, 60000, ErrorMessage ="Salary MUST be between 6000 EGP and 60000 EGP")]
        public float Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime HiringDateAndTime { get; set; }


    }
}

