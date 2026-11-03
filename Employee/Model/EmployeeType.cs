using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    public class EmployeeType
    {
        [Key]
        public int EmmployeeTypeId { get; set; }
        [Required]
        public string TypeName { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
