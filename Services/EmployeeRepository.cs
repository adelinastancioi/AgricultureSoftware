using AgriSoft.Context;
using AgriSoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriSoft.Services
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private FarmContext _context;

        public EmployeeRepository(FarmContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.Include(x => x.Tasks).OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<AgriSoft.Models.Task> GetTasks()
        {
            return _context.Tasks.OrderBy(x => x.TaskId).ToList();
        }


    }
}
