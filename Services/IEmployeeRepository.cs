using AgriSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriSoft.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<AgriSoft.Models.Task> GetTasks();
        IEnumerable<Employee> GetEmployees();
    }
}
