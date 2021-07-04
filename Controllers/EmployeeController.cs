using AgriSoft.DTO;
using AgriSoft.Models;
using AgriSoft.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPut("save-task")]
        public async Task<IActionResult> SaveEmployeeTask([FromBody] AgriSoft.Models.Task task)
        {
            await _employeeRepository.SaveEmployeeTask(task);
            return Ok();
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var result =  await _employeeRepository.GetTasks();
            return Ok(result);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _employeeRepository.GetEmployees();
            return Ok(result);
        }

        [HttpPut("save-employee")]
        public async Task<IActionResult> SaveEmployeeTask([FromBody] Employee employee)
        {
            await _employeeRepository.SaveEmployee(employee);
            return Ok();
        }

        [HttpGet("employee-tasks")]
        public async Task<IActionResult> GetEmployeeTasks([FromQuery] int employeeId)
        {
            var result = await _employeeRepository.GetEmployeeTasks(employeeId);
            return Ok(result);
        }
    
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] EmployeeLogin employee)
        {
           var res = await _employeeRepository.GetLogin(employee);
           return Ok(res);
        }

        [HttpDelete("remove-employee")]
        public async Task<IActionResult> RemoveEmployee([FromQuery] int employeeId)
        {
            await _employeeRepository.RemoveEmployee(employeeId);
            return Ok();
        }

        [HttpDelete("remove-task")]
        public async Task<IActionResult> RemoveTask([FromQuery] int taskId)
        {
            await _employeeRepository.RemoveTask(taskId);
            return Ok();
        }

    }
}
