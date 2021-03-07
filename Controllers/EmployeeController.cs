using AgriSoft.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("tasks")]
        public IActionResult GetTasks()
        {
            var result =  _employeeRepository.GetTasks();
            return Ok(result);
        }

        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            var result = _employeeRepository.GetEmployees();
            return Ok(result);
        }
    }
}
