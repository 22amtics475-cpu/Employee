using System.ComponentModel.DataAnnotations;

namespace Employee.Dtos
{
    public class CreateEmployeeType
    {
        [Required]
        public string TypeName { get; set; } = string.Empty;
    }
}
