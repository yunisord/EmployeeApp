using EmployeeApp.Data;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Get All Employees
        [HttpGet]
public async Task<ActionResult<IEnumerable<EmployeeRecord>>> GetEmployees()
{
    var employees = await _context.Employees.ToListAsync();

    Console.WriteLine($"🔍 Found {employees.Count} employees in the database.");
    
    return employees;
}

        // ✅ Add Employee (Explicitly using [FromBody])
       [HttpPost]
public async Task<ActionResult<EmployeeRecord>> AddEmployee([FromBody] EmployeeRecord employee)
{
    if (employee == null)
    {
        Console.WriteLine("❌ Received null employee data.");
        return BadRequest("Invalid employee data.");
    }

    Console.WriteLine($"🟢 Attempting to add Employee: {employee.Name}, {employee.Position}, {employee.Salary}");

    _context.Employees.Add(employee);
    int saveResult = await _context.SaveChangesAsync();

    if (saveResult == 0)
    {
        Console.WriteLine("❌ Employee was NOT saved to the database!");
        return StatusCode(500, "Could not save employee.");
    }

    Console.WriteLine("✅ Employee successfully saved!");
    return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
}


       // ✅ Update Employee
[HttpPut("{id}")]
public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRecord employee)
{
    if (id != employee.Id) return BadRequest("Employee ID mismatch");

    var existingEmployee = await _context.Employees.FindAsync(id);
    if (existingEmployee == null) return NotFound("Employee not found");

    // Update fields manually to prevent overwriting unintended fields
    existingEmployee.Name = employee.Name;
    existingEmployee.Position = employee.Position;
    existingEmployee.Salary = employee.Salary;

    await _context.SaveChangesAsync();
    return NoContent();
}

// ✅ Delete Employee by ID
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteEmployee(int id)
{
    var employee = await _context.Employees.FindAsync(id);

    if (employee == null)
    {
        Console.WriteLine($"❌ Employee with ID {id} not found.");
        return NotFound("Employee not found");
    }

    Console.WriteLine($"🗑️ Deleting Employee: {employee.Name}");

    _context.Employees.Remove(employee);
    await _context.SaveChangesAsync();

    return NoContent(); // 204 No Content (successful deletion)
}


    }
}
