using System.ComponentModel.DataAnnotations;

namespace Employee.Dtos
{
    public class CreateEmployee
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;

        [Required]
        public DateOnly JoiningDate { get; set; }

        [Range(18, 50)]
        public int Age { get; set; }

        public int Salary { get; set; }

        [Required]
        public string EmployeeCode { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int EmmployeeTypeId { get; set; }
    }
}
