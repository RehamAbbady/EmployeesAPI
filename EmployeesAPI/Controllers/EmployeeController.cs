using EmployeesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());

        }
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            Employee dbEmployee=await _context.Employees.FindAsync(employee.Id);
            if (dbEmployee == null)
                return BadRequest("Employee does not exist");
            dbEmployee.FirstName=employee.FirstName;
            dbEmployee.LastName=employee.LastName;
            dbEmployee.DepartmentId=employee.DepartmentId;
           
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            Employee dbEmployee = await _context.Employees.FindAsync(id);
            if (dbEmployee == null)
                return BadRequest("Employee does not exist");
            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());

        }
    }
}
