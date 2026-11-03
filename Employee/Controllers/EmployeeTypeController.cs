using Employee.Dtos;
using Employee.Model;
using Employee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _repository;

        public EmployeeTypeController(IEmployeeTypeRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(
       [FromBody] CreateEmployeeType request)
        {
            string[] allowedTypes = { "Hybrid", "Remote", "PartTime", "FullTime" };

            if (!allowedTypes.Contains(request.TypeName, StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new
                {
                    message = "TypeName must be Hybrid, Remote, PartTime, or FullTime."
                });
            }

            var typeName = allowedTypes.First(
                type => type.Equals(request.TypeName, StringComparison.OrdinalIgnoreCase));

            if (await _repository.TypeNameExistsAsync(typeName))
                return Conflict(new { message = "This employee type already exists." });

            var created = await _repository.AddAsync(new EmployeeType
            {
                TypeName = typeName
            });

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.EmmployeeTypeId },
                created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeType = await _repository.GetByIdAsync(id);

            return employeeType is null
                ? NotFound(new { message = "Employee type not found." })
                : Ok(employeeType);
        }
    }
}
