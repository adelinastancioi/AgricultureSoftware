using AgriSoft.Context;
using AgriSoft.DTO;
using AgriSoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = AgriSoft.Models.Task;

namespace AgriSoft.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private FarmContext _context;

        public EmployeeRepository(FarmContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task SaveBulk<T>(IEnumerable<T> elements) where T : class
        {
            if (elements == null)
                return;

            await _context.AddRangeAsync(elements);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateBulk<T>(IEnumerable<T> elements) where T : class
        {
            if (elements == null)
                return;

            _context.Set<T>().UpdateRange(elements);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveBulk<T>(IEnumerable<T> elements) where T : class
        {
            if (elements == null)
                return;

            _context.RemoveRange(elements);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Save<T>(T element) where T : class
        {
            await _context.AddAsync(element);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Remove<T>(T element) where T : class
        {
            _context.RemoveRange(element);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update<T>(T element) where T : class
        {
            _context.Set<T>().Update(element);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(x => x.Tasks)
                .OrderBy(x => x.Id)
                .ToListAsync();
            return employees;
        }

        public  Employee GetEmployee(int id)
        {
            var employee =  _context.Employees
                .Include(x => x.Tasks)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return employee;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async System.Threading.Tasks.Task RemoveEmployee(int employeeId)
        {
            var employee = GetEmployee(employeeId);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }         
        }

        public async System.Threading.Tasks.Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Task>> GetTasks()
        {
            var tasks = await _context.Tasks.OrderBy(x => x.TaskId).ToListAsync();
            return tasks;
        }

        public async Task<List<Task>> GetEmployeeTasks(int employeeId)
        {
            var tasks = await _context.Tasks
                .Where(x => x.EmployeeId == employeeId)
                .OrderBy(x => x.TaskId)
                .ToListAsync();
            return tasks;
        }

        public async System.Threading.Tasks.Task SaveEmployeeTask(Task task)
        {
            if (task.TaskId == 0)
                _context.Tasks.Add(task);
            else
                _context.Tasks.Update(task);

            await _context.SaveChangesAsync();
        }

        public Task<bool> GetLogin(EmployeeLogin login)
        {
            return _context.Employees
                .AnyAsync(x => x.Mail == login.Mail && x.Password == login.Password);
        }

        public async System.Threading.Tasks.Task RemoveTask(int taskId)
        {
            var task = _context.Tasks
                .Where(x => x.TaskId == taskId)
                .FirstOrDefault();

            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
                _context.Employees.Update(employee);

            await _context.SaveChangesAsync();
        }
    }
}
