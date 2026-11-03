using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Model
{
    [Index(nameof(EmployeeCode), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
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
        public string EmployeeCode { get; set; } = string.Empty;

        [ForeignKey(nameof(EmployeeType))]
        public int EmmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }
    }
}
