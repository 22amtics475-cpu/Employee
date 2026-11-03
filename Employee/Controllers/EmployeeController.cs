using Employee.Dtos;
using Employee.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("joined-this-month")]
        public async Task<IActionResult> GetJoinedThisMonth()
        {
            return Ok(await _repository.GetJoinedThisMonthAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            return employee is null
                ? NotFound(new { message = "Employee not found." })
                : Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateEmployee request)
        {
            if (await _repository.EmployeeCodeExistsAsync(request.EmployeeCode))
                return Conflict(new { message = "Employee code already exists." });

            if (!await _repository.EmployeeTypeExistsAsync(request.EmmployeeTypeId))
                return BadRequest(new { message = "Employee type does not exist." });

            var employee = new Employee.Model.Employee
            {
                Name = request.Name,
                EmailId = request.EmailId,
                JoiningDate = request.JoiningDate,
                Age = request.Age,
                Salary = request.Salary,
                EmployeeCode = request.EmployeeCode,
                EmmployeeTypeId = request.EmmployeeTypeId
            };

            var created = await _repository.AddAsync(employee);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            return deleted
                ? NoContent()
                : NotFound(new { message = "Employee not found." });
        }
    }
}
